namespace StoneAssemblies.Hikvision.Services
{
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

        public async IAsyncEnumerable<UserInfo> ListUserAsync(params string[] employeeNumbers)
        {
            var searchCond = new UserInfoSearchCond();

            if (employeeNumbers.Length > 0)
            {
                searchCond.EmployeeNoList = employeeNumbers
                    .Select(employeeNumber => new EmployeeNoListItem { EmployeeNo = employeeNumber }).ToList();
            }

            await foreach (var userInfo in this.SearchUserAsync(searchCond))
            {
                yield return userInfo;
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

        private async IAsyncEnumerable<UserInfo> SearchUserAsync(UserInfoSearchCond searchCond)
        {
            ArgumentNullException.ThrowIfNull(searchCond);

            searchCond.SearchID = this.searchIdGenerationService.Next();
            searchCond.SearchResultPosition = 0;
            searchCond.MaxResults = 10;

            try
            {
                var userInfoSearch = await this.httpClient.PostAsync<UserInfoSearchCond, UserInfoSearch>(EndPoints.Json.UserInfoSearch, searchCond);
                while (userInfoSearch?.UserInfo is not null)
                {
                    foreach (var userInfo in userInfoSearch.UserInfo)
                    {
                        yield return userInfo;
                    }

                    searchCond.SearchResultPosition += userInfoSearch.UserInfo.Count;
                    userInfoSearch = await this.httpClient.PostAsync<UserInfoSearchCond, UserInfoSearch>(EndPoints.Json.UserInfoSearch, searchCond);
                }
            }
            finally
            {
                this.searchIdGenerationService.Release(searchCond.SearchID);
            }
        }
    }
}