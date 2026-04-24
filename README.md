Для запуска проекта вам потребуется:
- .NET 9.0+ SDK
- PostgreSQL

Шаги:
1. Скачать репозиторий
2. Настроить его на работу с вашей ДБ.
     2.1 Если вы используете PostgreSQL то вам необходимо просто создать там отдельную таблицу по названием "Orders" или создать отдельную БД и в ней создать эту таблицу
3. В корне проекта (там же где находится Program.cs) создать файл appsettings.Development.json и написать там следующий код:
```json
{
  "ConnectionStrings": {
    "ConnectionString": "Host=localhost;Database=[db_name];Username=[db_username];Password=[db_password];Port=5432"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
```
где: [db_name] - имя вашей БД
[db_username] - логин вашей БД
[db_password] - пароль вашей БД
4. Обновить базу данных
```bash
dotnet ef database update
```
5. Запустить проект

P.S.: файл appsettings.Development.json не попадает в репозиторий.
