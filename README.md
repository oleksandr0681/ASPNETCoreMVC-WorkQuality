# Work Quality

Web-застосунок для моніторингу якості роботи працівників ІТ-підприємства. Працівники можуть оцінюватись по 11 критеріям.

Створено за допомогою **ASP.NET Core MVC**, **T-SQL**, **Entity Framework Core**, **ApexCharts** для візуалізації даних і **ASP.NET Core Identity** для автентифікації.

---

## Попередні вимоги

- .NET 7.0

## Початок роботи

### 1. Створити копію репозиторію

git clone < repository-url >

### 2. Відкрити проект у Microsoft Visual Studio

### 3. Запустити проект

Debug - Start Debugging

При першому запуску з'являться діалогові вікні "Trust ASP.NET Core SSL Certificate", "Попередження системи безпеки". Потрібно вибрати "Yes" ("Так").

<img width="575" height="225" alt="1" src="https://github.com/user-attachments/assets/380181ba-833a-4ef2-a7d3-cc823f14832e" />

<img width="467" height="438" alt="2" src="https://github.com/user-attachments/assets/6ecd7376-abea-4719-9549-603ebe3853aa" />

Проект відкриється у web-браузері.


<img width="1365" height="719" alt="Screenshot 2026-07-07 191813" src="https://github.com/user-attachments/assets/68aa879c-e8a7-4baa-a476-566cc43a75f0" />


При запуску web-застосунку створюється дві бази даних: workQualityDb і workQualityIdentityDb. В першій базі даних зберігаються посади, працівники і оцінки. В другій – користувачі програми (файл appsettings.json). Додається користувач з правами адміністратора. Ім'я користувача, Email: admin@example.com, пароль: Qwerty+1 (файл Program.cs).

В базу даних workQualityDb додаються дві посади за замовчуванням.

<img width="1365" height="717" alt="Screenshot 2026-07-07 194556" src="https://github.com/user-attachments/assets/bb3f8fa2-3baf-41eb-a09b-6500f72c53bd" />

## Можливості

Додавати, змінювати посади можуть тільки користувачі з роллю  Administrator. Administrator може змінити ролі (права доступу) користувача.

Додавати, змінювати працівників і оцінювання можуть користувачі з роллю ManagementSpecialist і з роллю  Administrator.

Переглядати посади, працівників, оцінювання і їх подробиці можуть всі.


<img width="1365" height="719" alt="Screenshot 2026-07-07 194857" src="https://github.com/user-attachments/assets/e7effec3-e475-4ea4-aa77-a0e5be73cbd6" />

<img width="1365" height="715" alt="Screenshot 2026-07-07 195454" src="https://github.com/user-attachments/assets/54a037a9-e803-4971-a121-b38fb6ec699d" />


Сутність Job описує посаду. Там зберігається назва посади, опис і коефіцієнти пріоритетності критеріїв оцінювання якості роботи працівників. Якщо який критерій для даної посади не потрібно оцінювати, для цього коефіцієнта призначається значення 0.

Сутність Employee описує працівника. В ній зберігається прізвище, ім'я, по батькові (одна властивість), посада, характеристика і список оцінювань.

Сутність Assessment описує оцінювання. В ній зберігається працівник, дата оцінювання, оцінки (приймають значення від 1 до 5) і рейтинг. Можуть виставлятись не всі оцінки, а тільки ті, які потрібні. Рейтинг розраховується як сума оцінок помножених на відповідний коефіцієнт пріоритетності критерія оцінювання. Рейтинг розраховується в контролері AssessmentsController в методі дії Create і в методі дії Edit.

В подробицях про працівників (представлення Employees/Details) показана інформація про працівника і список з оцінюванням (дата оцінювання і рейтинг).

В подробицях про оцінювання (представлення Assessments/Details)  показана інформація про дату оцінювання, оцінки працівника, і рейтинг.


<img width="1365" height="719" alt="Screenshot 2026-07-07 200459" src="https://github.com/user-attachments/assets/da113d28-cc93-4b33-8386-1aafdaf5db75" />


<img width="1365" height="719" alt="Screenshot 2026-07-07 200603" src="https://github.com/user-attachments/assets/f2bbc34e-faae-4b0e-91d3-8cf334b986eb" />


<img width="1363" height="717" alt="Screenshot 2026-07-07 200833" src="https://github.com/user-attachments/assets/6c92a466-88bc-40d3-9c52-202b07dabe09" />


<img width="1365" height="720" alt="Screenshot 2026-07-07 201051" src="https://github.com/user-attachments/assets/0f31c68e-cbf8-405d-8646-0da600195026" />


<img width="1365" height="717" alt="Screenshot 2026-07-07 201528" src="https://github.com/user-attachments/assets/f2bef877-c9af-4ada-9fcd-6536640f7511" />


<img width="1365" height="719" alt="Screenshot 2026-07-07 203225" src="https://github.com/user-attachments/assets/64376bbe-3a53-4cb2-875b-c17342dd38d8" />


<img width="1365" height="720" alt="Screenshot 2026-07-07 203426" src="https://github.com/user-attachments/assets/f2654ad5-62eb-42c8-a4e3-f74de60f2725" />


<img width="1365" height="719" alt="Screenshot 2026-07-07 203740" src="https://github.com/user-attachments/assets/cf778b38-2c25-45e4-90d2-39826c746f12" />




