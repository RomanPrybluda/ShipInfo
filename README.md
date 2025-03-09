### ShipInfo
The service provides access to information about civil fleet vessels.

Site swagger link [ship-info](http://ship-info.runasp.net/swagger/index.html)

### User Story
#### Registered users
Registered users can search for a vessel by IMO number or vessel name.
An advanced search by parameters is also possible.
#### Administrators
Administrators have the option to:
- view, delete and create ships, engines and other entities
- view and delete users.

### STACK
.NET 8, EF Core.

### NOTE
The project is under development.
Scope of the project back-end part (Web API).
At the moment, ShipInfo.DAL is fully developed.
ShipInfo.DOMAIN and ShipInfo.WebAPI are under development.
