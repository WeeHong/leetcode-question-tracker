# LeetCode Question Exporter
The purpose of the application is to export the LeetCode Question from the database to CSV file.

## Getting Started
1. Create a dotnet user secret
    ```
    dotnet user-secrets init
    dotnet user-secrets set "NotionDatabase" "<NotionDatabaseId>"
    dotnet user-secrets set "NotionVersion" "<NotionVersion>"
    dotnet user-secrets set "NotionToken" "<NotionToken>"
    ```
    You can obtain the NotionToken from [here](https://www.notion.so/my-integrations)
