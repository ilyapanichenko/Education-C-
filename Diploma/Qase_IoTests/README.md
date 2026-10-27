# Qase.io — автоматизированное тестирование

Учебный проект автоматизации тестирования API и веб-интерфейса Qase.io на C# и .NET 10.

Реализованы проверки работы с проектами, тест-кейсами, наборами тестов и авторизацией. Проект включает API-, UI- и BDD-тесты.

## Стек

- **C# / .NET 10** — основной язык и платформа
- **NUnit** — тестовый фреймворк
- **RestSharp** — HTTP-запросы к API
- **Selenium WebDriver** — автоматизация браузера
- **Reqnroll** — BDD-сценарии на Gherkin
- **Serilog** — логирование
- **Allure** — отчёты о выполнении тестов
- **GitHub Actions** — CI/CD

## Структура проекта

```text
Qase_IoTests/
├── Qase_IoTests.Core/
│   ├── Api/
│   ├── Configuration/
│   ├── Logging/
│   ├── Models/
│   ├── Pages/
│   ├── Utilities/
│   └── WebDriver/
├── Qase_IoTests.Tests/
│   ├── ApiTests/
│   ├── BaseTests/
│   ├── BDD/
│   ├── Helpers/
│   └── UiTests/
└── Qase_IoTests.sln
```

`Qase_IoTests.Core` содержит общие компоненты: API-клиент, DTO, Page Object, фабрику WebDriver, конфигурацию и логирование.

`Qase_IoTests.Tests` содержит тестовые классы, BDD-сценарии и вспомогательные методы.

## Конфигурация

Для запуска требуется .NET SDK 10. Для UI-тестов необходим установленный Chrome, Firefox или Edge.

Данные для авторизации передаются через переменные окружения:

```powershell
$env:QASE_API_KEY = '...'
$env:QASE_UI_EMAIL = '...'
$env:QASE_UI_PASSWORD = '...'
```

Параметры браузера задаются в `Qase_IoTests.Tests/appsettings.json`:

```json
{
  "Browser": "chrome",
  "Headless": false
}
```

Поддерживаются `chrome`, `firefox` и `edge`.

## Запуск тестов

Команды выполняются из корня репозитория.

Восстановление зависимостей:

```bash
dotnet restore Diploma/Qase_IoTests/Qase_IoTests.sln
```

Запуск API-тестов:

```bash
dotnet test Diploma/Qase_IoTests/Qase_IoTests.sln --filter "FullyQualifiedName~ApiTests"
```

Запуск UI- и BDD-тестов:

```bash
dotnet test Diploma/Qase_IoTests/Qase_IoTests.sln --filter "FullyQualifiedName~UiTests|FullyQualifiedName~BDD"
```

## CI/CD и отчётность

Автоматизация настроена через GitHub Actions.

Workflow `qase-tests.yml` запускает API-тесты и UI/BDD-тесты в Chrome, Firefox и Edge. Результаты выполнения сохраняются как артефакты независимо от статуса тестового прогона.

Workflow `allure-report.yml` формирует отдельные Allure-отчёты для API и каждого браузера с последующей публикацией на GitHub Pages.

- [Allure Report](https://ilyapanichenko.github.io/Education-C-/)
- [GitHub Actions](https://github.com/ilyapanichenko/Education-C-/actions)

## Ограничения

Qase.io применяет ограничения на количество запросов авторизации. При параллельном запуске UI-тестов возможны ошибки превышения лимита входов.

Тест создания проекта через API отключён атрибутом `[Ignore]` из-за ограничений используемого тарифного плана Qase.
