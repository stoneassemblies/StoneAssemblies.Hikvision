namespace StoneAssemblies.Hikvision.Services;

using StoneAssemblies.Hikvision.Models;
using StoneAssemblies.Hikvision.Services.Interfaces;

public class UserInfoClient : IUserInfoClient
{
    private readonly HttpClient httpClient;

    private readonly ISearchIdGenerationService searchIdGenerationService;

    public UserInfoClient(HttpClient httpClient, ISearchIdGenerationService searchIdGenerationService)
    {
        this.httpClient = httpClient;
        this.searchIdGenerationService = searchIdGenerationService;
    }

    public async IAsyncEnumerable<UserInfo> ListUserAsync()
    {
        var request = new UserInfoSearchCond
        {
            SearchID = this.searchIdGenerationService.Next(),
            SearchResultPosition = 0,
            MaxResults = 10,
        };

        try
        {
            var userInfoSearch = await this.httpClient.PostAsync<UserInfoSearchCond, UserInfoSearch>(EndPoints.Json.UserInfoSearch, request);

            while (userInfoSearch?.UserInfo is not null)
            {
                foreach (var userInfo in userInfoSearch.UserInfo)
                {
                    yield return userInfo;
                }

                request.SearchResultPosition += userInfoSearch.UserInfo.Count;
                userInfoSearch = await this.httpClient.PostAsync<UserInfoSearchCond, UserInfoSearch>(EndPoints.Json.UserInfoSearch, request);
            }
        }
        finally
        {
            this.searchIdGenerationService.Release(request.SearchID);
        }
    }

    public async Task UpdateUserAsync(UserInfo userInfo)
    {
        await this.httpClient.PutAsync(EndPoints.Json.UserInfoModify, userInfo);
    }

    public async Task AddUserAsync(UserInfo userInfo)
    {
        await this.httpClient.PostAsync(EndPoints.Json.UserInfoRecord, userInfo);
    }
}