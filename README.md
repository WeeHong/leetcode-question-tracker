# LeetCode Question Exporter
The purpose of the application is to export the LeetCode Question from the database to CSV file.

## Pre-requisite
You need to have a local database which stored all the database to start this application.
You may find the crawler from my [Golang LeetCode Fetcher repo](https://github.com/WeeHong/leetcode-question-fetcher)

## Getting Started
1. Create a dotnet user secret
    ```
    dotnet user-secrets init
    dotnet user-secrets set "NotionDatabase" "<NotionDatabaseId>"
    dotnet user-secrets set "NotionVersion" "<NotionVersion>"
    dotnet user-secrets set "NotionToken" "<NotionToken>"
    ```
    You can obtain the NotionToken from [here](https://www.notion.so/my-integrations)
