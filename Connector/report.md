# Metadata Report

Findings from the metadata extraction process.

## Breaking Changes

These changes to the Connector's metadata break how integrations could be leveraging the Connector. These changes are not safe to be applied to Xchange.

No breaking changes found.

## Non-Breaking Changes

These changes expand or maintain the Connector's metadata and are safe to be applied to Xchange.

- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/CreatePaystubEmployeesConfig` Property added to the schema without being required.
- `app/1` (Action): `employees/create-paystub`  Action is being added
- `app/1` (Real Time Action Processing): `employees/create-paystub`  Real time action processing is being added
