using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TeamHost.Application.Extensions;
using TeamHost.Application.Interfaces;
using TeamHost.Domain.Entities;

namespace TeamHost.Application.Features.Queries.Profile.EditProfile;

public class PutEditProfileCommandHandler : IRequestHandler<PutEditProfileCommand, bool>
{
    private readonly IDbContext _dbContext;
    private readonly IUserContext _userContext;
    private readonly IWebHostEnvironment _webHostEnvironment;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="dbContext">Контекст БД</param>
    /// <param name="userContext">Контекст пользователя</param>
    /// <param name="webHostEnvironment">Рут</param>
    public PutEditProfileCommandHandler(
        IDbContext dbContext,
        IUserContext userContext,
        IWebHostEnvironment webHostEnvironment)
    {
        _dbContext = dbContext;
        _userContext = userContext;
        _webHostEnvironment = webHostEnvironment;
    }

    /// <inheritdoc />
    public async Task<bool> Handle(PutEditProfileCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        var userFromDb = await _dbContext.Users
            .Include(x => x.UserInfo)
                .ThenInclude(y => y.Country)
            .Include(x => x.UserInfo)
                .ThenInclude(y => y.Image)
            .FirstOrDefaultAsync(x => x.Id == _userContext.CurrentUserId!.Value, cancellationToken)
            ?? throw new ApplicationException("Пользователь не найден");

        var country = await _dbContext.Countries
            .FirstOrDefaultAsync(x => x.Id == request.Country, cancellationToken)
            ?? throw new ApplicationException("Не найдена страна");
        
        if (userFromDb.UserInfo is null)
            throw new ArgumentNullException(nameof(userFromDb.UserInfo));
        
        var oldProfileImage = userFromDb.UserInfo.Image;
        var profileImage = await UploadProfileImageFileAsync(request.ProfileImage, cancellationToken);

        if (profileImage != null && oldProfileImage != null)
        {
            _dbContext.MediaFiles.Remove(oldProfileImage);
            File.Delete(Path.Combine(_webHostEnvironment.WebRootPath, oldProfileImage.Path ?? string.Empty));
        }

        userFromDb.UserInfo.UpdateInfo(
            firstName: request.FirstName,
            lastName: request.LastName,
            patronomic: request.Patronymic,
            about: request.About,
            birthday: request.Birthday.GetCorrectDateTime(),
            country: country,
            image: profileImage);

        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    private async Task<MediaFile?> UploadProfileImageFileAsync(IFormFile? file, CancellationToken cancellationToken)
    {
        var profileImage = new MediaFile();

        if (file is null)
            return null;
        
        var uniqueFileName = $"{Guid.NewGuid()}_{file.FileName}";
        var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "profiles", uniqueFileName);
        var filePathForDb = $"profiles/{uniqueFileName}";
        
        profileImage = new MediaFile
        {
            Name = uniqueFileName,
            Path = filePathForDb,
            Size = (ulong)file.Length!
        };

        await using var fileStream = new FileStream(uploadFolder, FileMode.Create);
        await file.CopyToAsync(fileStream, cancellationToken);

        return profileImage;
    }
}