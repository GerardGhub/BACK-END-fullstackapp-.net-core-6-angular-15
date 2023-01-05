# BACK-END-fullstackapp-.net-core-7-angular-15


Angular CRUD WITH .NET CORE

//Previous setup before updating 
ng --version 12 - 14
dotnet --version 7
node --v 16.6 - 18.12

npm uninstall -g @angular/cli

npm install -g @angular/cli@latest
ng version

Angular CLI: 15.0.4
Node: 18.12.1
Package Manager: npm 8.19.2
OS: win

<<add folder>>
client folder
ng new fullstackapp
? Would you like to add Angular routing? (y/N)  y 
stylesheet - i prepared scss

cd src/app/components/employees
ng g c employees-list


add dependecies 
Microsoft entity framework core sql server
and Microsoft Entity Framework tools 


Add-Migration "Initial Migration"

Update-Database

ng g s employees
ng g c add-employee
ng g c edit-employee
