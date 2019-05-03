## User Management
1. Enable client to resigster Accounts. Done
2. Admin Role User can add employees and link them with active directory.
3. Client and Employee Login (Employee with AD & Client through DB). Done
4. HttpContext And DI. Done
5. Each Sub Account Orders is hidden from others.
6. Each Sub Account have list of industrial cities. Done
7. Notifications Sent to sub accounts and his parent.

## Notes 11//3/2019
1. Add httpaccessor to BaseControoler Done
2. Move ReadModels from web to ViewModels Done
3. Use Tr.t() instead of ResourceManager Done
4. Change SubClient to SubAccount  Done
5. Remove Infranstucture ref from web Done
6. Remove default password for new accounts Done
7. Create Migration file and add SQL Storeds in it.
8. Add Login Validations Done
9. Add Confirm Mobile to registrations 
10. Use the following fileds in UserAccount Done
- string FullName
- list<IndustrialCity> AllowedIndustrialCities
- List<Permissions>
- List<Roles>
11. Use the following fileds in ClientAccount Done
- string ClientFullName
- string OrganizationName
- string  fax
- string HeadOfficeAddress
- string mobile 
11. Add Permissions has some data like 
- ReceiveAppNotifications Done (Added to UserAccount Table)
- ReceiveEmailNotifications Done (Added to UserAccount Table)
- ReceiveSMSNotifications Done (Added to UserAccount Table)
- AddSubAccount
---------------
12. Create Admin user from seeds Done
13. Test admin login Done
13. Show employee layout to the admin
14. Add new screen for AddEmployee for the admin
15. login with another employee
--------------
## Notes 14//3/2019
- SMS confirmation
- Employee Layout (Old Project Had only one layout used)
- Fix layout missing parts like menu, notifcations, username Done
- 