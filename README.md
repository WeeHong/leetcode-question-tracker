# LeetCode Question Tracker
This application helps user who practices LeetCode to keep track of their study progression.

When user mark their questions as **"To Revise"**, then the application will create a reminder as a task on Todoist.

The best use of this application is to create a task scheduler and run it automatically.

## Feature
- Export LeetCode questions to CSV
- Export LeetCode questions to Notion
- Create a revise reminder on Todoist

## Pre-requisite
You need to have a local database which stored all the database to start this application.<br/>
You may find the crawler from my [Golang LeetCode Fetcher repo](https://github.com/WeeHong/leetcode-question-fetcher)

## Getting Started
1. Create a dotnet user secret
    ```
    dotnet user-secrets init
    dotnet user-secrets set "NotionDatabase" "<NotionDatabaseId>"
    dotnet user-secrets set "NotionVersion" "<NotionVersion>"
    dotnet user-secrets set "NotionToken" "<NotionToken>"
    dotnet user-secrets set "TodoistToken" "<TodoistToken>"
    ```
    You can obtain the Notion Token from [here](https://www.notion.so/my-integrations)
    You can obtain the Todoist Token from [here](https://todoist.com/app/settings/integrations) 
