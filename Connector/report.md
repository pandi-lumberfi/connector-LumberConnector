# Metadata Report

Findings from the metadata extraction process.

## Breaking Changes

These changes to the Connector's metadata break how integrations could be leveraging the Connector. These changes are not safe to be applied to Xchange.

- `customAuth` (Connection Definition):  Connection definition property 'apiKey' will change from 'String' to 'string'
- `customAuth` (Connection Definition):  Connection definition property 'apiSecretKey' will change from 'String' to 'string'
- `customAuth` (Connection Definition):  Connection definition property 'userId' will change from 'String' to 'string'
- `customAuth` (Connection Definition):  Connection definition property 'connectionEnvironment' will change from 'String' to 'string'

## Non-Breaking Changes

These changes expand or maintain the Connector's metadata and are safe to be applied to Xchange.

- Connector (Details):  Name will be changing
- `customAuth` (Connection Definition):  Connection definition property 'apiKey' will now be sensitive
- `customAuth` (Connection Definition):  Connection definition property 'apiSecretKey' will now be sensitive
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/CreateCompCodeConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/UpdateCompCodeConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/CreateDepartmentConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/UpdateDepartmentConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Cache Writer` `/properties/CompCodeConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Cache Writer` `/properties/DepartmentConfig` Property added to the schema without being required.
- `app/1` (Data Object): `employees` `/properties/user_benefits` Property added to the schema without being required.
- `app/1` (Data Object): `employees` `/properties/bank_accounts` Property added to the schema without being required.
- `app/1` (Data Object): `comp-code`  Data object is being added
- `app/1` (Data Object Key): `comp-code/id`  Data object key is being added
- `app/1` (Action): `comp-code/create`  Action is being added
- `app/1` (Real Time Action Processing): `comp-code/create`  Real time action processing is being added
- `app/1` (Action): `comp-code/update`  Action is being added
- `app/1` (Real Time Action Processing): `comp-code/update`  Real time action processing is being added
- `app/1` (Data Object): `department`  Data object is being added
- `app/1` (Data Object Key): `department/id`  Data object key is being added
- `app/1` (Action): `department/create`  Action is being added
- `app/1` (Real Time Action Processing): `department/create`  Real time action processing is being added
- `app/1` (Action): `department/update`  Action is being added
- `app/1` (Real Time Action Processing): `department/update`  Real time action processing is being added
