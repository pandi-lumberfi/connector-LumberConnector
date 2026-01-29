# Metadata Report

Findings from the metadata extraction process.

## Breaking Changes

These changes to the Connector's metadata break how integrations could be leveraging the Connector. These changes are not safe to be applied to Xchange.

No breaking changes found.

## Non-Breaking Changes

These changes expand or maintain the Connector's metadata and are safe to be applied to Xchange.

- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/UpdatePaySplitEmployeesConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/UpdateTaxWithHoldingEmployeesConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Cache Writer` `/properties/UserDemographicsConfig` Property added to the schema without being required.
- `app/1` (Data Object): `employees` `/properties/bank_accounts/#/type/Array/#/type/Object/#/properties/source_system` Property added to the schema without being required.
- `app/1` (Data Object): `employees` `/properties/bank_accounts/#/type/Array/#/type/Object/#/properties/source_system_id` Property added to the schema without being required.
- `app/1` (Action): `employees/add-bank-account` `/properties/source_system` Property added to the schema without being required.
- `app/1` (Action): `employees/add-bank-account` `/properties/source_system_id` Property added to the schema without being required.
- `app/1` (Action): `employees/add-bank-account` `/properties/id/#/AnyOf` Updated schema was changed to allow the types: Null,String
- `app/1` (Action): `employees/update-pay-split`  Action is being added
- `app/1` (Real Time Action Processing): `employees/update-pay-split`  Real time action processing is being added
- `app/1` (Action): `employees/update-tax-with-holding`  Action is being added
- `app/1` (Real Time Action Processing): `employees/update-tax-with-holding`  Real time action processing is being added
- `app/1` (Data Object): `user-demographics`  Data object is being added
- `app/1` (Data Object Key): `user-demographics/id`  Data object key is being added
