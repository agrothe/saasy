# saasy
SaaSy Framework - ASPNET Core development SaaS starter kit

### Status
CircleCI Build - [![CircleCI](https://circleci.com/gh/agrothe/saasy.svg?style=svg)](https://circleci.com/gh/agrothe/saasy)

## Development Starter
Tired of always starting from the same place, this starter project will provide a template providing:

* Multi-tenant architecture
* Localization & Globalization at all levels (Database, Service, View)
* Authentication (ASP.NET Identity)
  * Individual accounts
  * OAuth providers
  * Active Directory provider
  * 2nd Factor authentication
* Claim based authorization with granular permissions
* User management
* Tenant management

### Routing
Routing is defined as:

`https://domain.com/{locale}/{tenant code}/{area?}/{controller}/{action}/{params?}/`

For example, our login page will be

`https://domain.com/en/app/identity/account/login`

The default base tenant is defined as "app", so if you don't wish to have a multi-tenant application you can disable the creation of new tenants and just roll with the default.
