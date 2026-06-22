# ShopApp (сгенерировано шаблоном Miksist)

## Что нужно сделать сразу после генерации

1. В `Server/appsettings.json` замените строку подключения на данные вашей реальной БД:
   ```json
   "DefaultConnection": "Server=localhost;Port=3306;Database=ВАША_БД;User=ВАШ_USER;Password=ВАШ_ПАРОЛЬ;"
   ```
2. Накатите миграции:
   ```bash
   cd Server
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```
3. Запустите Server, откройте `http://localhost:PORT/swagger`, проверьте CRUD через Swagger UI.
4. В `Client/Services/ApiService.cs` поправьте `BaseUrl`, если порт Server отличается от 5000.
5. Запустите Client (окно на Avalonia) — список должен подгрузиться из Server.

Подробное объяснение каждого шага — в исходном руководстве, по которому собран этот шаблон.
