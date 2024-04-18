const currentUser = document.getElementById('current-user-id').value;

const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:7046/ws/chat", {
        accessTokenFactory: () => currentUser
    })
    .build()

hubConnection.on("OnConnection", function(data) {
    console.log(data)
    for (let i = 0; i < data._usersOnline.length; i++){
        let parentNode = document.getElementById(`friend-id=${data._usersOnline[i]}`);

        console.log(`parent node: ${parentNode}`)

        if (parentNode !== null && parentNode !== undefined){
            let childNode = parentNode.querySelector('.user-item');
            childNode.classList.add('--active')
            childNode.offsetWidth;
        }
    }
})

hubConnection.on("OnDisconnected", function (data)  {
    console.log(data)
    
    let parentNode = document.getElementById(`friend-id=${data.userId}`);
    
    if (parentNode !== undefined){
        let childNode = parentNode.querySelector('.user-item');
        childNode.classList.remove('--active')
        childNode.offsetWidth;
    }
});

hubConnection.on("ReceiveMessage", function (data) {
    console.log(data)
    var currentUserId = document.getElementById('current-user-id').value;

    var isMyMessage = currentUserId === data.whoSentId;
    let senderName = data.senderName;

    var img = data.images.length > 1
        ? ""
        : data.images[0].image

    let senderMessage = `<div class="sender-name">${senderName}</div>`
    var avatar = `<div class="messages-item__avatar"><img src="~/${img}" alt="user"></div>`;
    var isYourMessage = isMyMessage ? '--friend-message' : '--your-message'

    console.log(avatar)
    // Создаем новый элемент сообщения
    var newMessage = `
        <div class="messages-item ${isYourMessage}" id="your-message"">
            ${isMyMessage ? "" : avatar}
            ${isMyMessage ? senderMessage : ""}
            <div class="messages-item__text">${data.text}</div>
            ${isMyMessage ? "" : senderMessage}
        </div>
    `;

    // Добавляем новое сообщение в конец списка
    $('.chat-messages-body').append(newMessage);

    // Обновляем высоту контейнера чата и прокручиваем вниз
    var chatMessagesBody = $('.chat-messages-body')[0];
    chatMessagesBody.scrollTop = chatMessagesBody.scrollHeight;
});


hubConnection.start();

// Функция для загрузки частичного представления чата
function loadChats() {
    $('.chat-user-list__body').load('/Account/Chat/Chats', function() {
        // После загрузки чатов, привязываем обработчик клика к элементам чата
        $('.user-item').off('click').on('click', function (event) {
            event.preventDefault(); // Предотвращаем стандартное действие ссылки
            var id = $(this).data('message-id'); // Получаем значение data-message-id
    
            $.ajax({
                url: `/GetMessageInChat/${id}`,
                type: 'GET',
                dataType: 'text',
                success: function (data) {
                    $('#chat-place').html(data);
                    attachFormSubmitHandler()

                    // Прокручиваем чат вниз после загрузки сообщений
                    var chatMessagesBody = $('.chat-messages-body')[0];
                    chatMessagesBody.scrollTop = chatMessagesBody.scrollHeight;
                },
                error: function () {
                    alert('Ошибка при загрузке данных');
                }
            });
        });
    });
}

// Загрузка чатов при загрузке страницы
$(document).ready(function () {
    loadChats();
});
// Функция для привязки обработчика отправки формы
function attachFormSubmitHandler() {
    // Находим форму внутри #chat-place и назначаем обработчик отправки
    $('#chat-place').on('submit', '#form-chat', function(event) {
        event.preventDefault(); // Предотвращаем стандартное действие отправки формы
        
        // Получаем данные из формы
        const formData = {
            message: `${document.querySelector('.chat-messages-input').value}`
        };

        const chatId = $('#chatIdInput').val();

        // Выполняем AJAX-запрос на сервер
        fetch(`/SendMessage/${chatId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        })
            .then()

        document.querySelector('.chat-messages-input').value = "";
    });
}