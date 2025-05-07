# Metadata Report

Findings from the metadata extraction process.

## Breaking Changes

These changes to the Connector's metadata break how integrations could be leveraging the Connector. These changes are not safe to be applied to Xchange.

No breaking changes found.

## Non-Breaking Changes

These changes expand or maintain the Connector's metadata and are safe to be applied to Xchange.

- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/CreateBranchConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/CreateTaskConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Action Processor` `/properties/UpdateTaskConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Cache Writer` `/properties/BranchConfig` Property added to the schema without being required.
- `app/1` (Service): `lumber-bdf65/app/1 Cache Writer` `/properties/TaskConfig` Property added to the schema without being required.
- `app/1` (Data Object): `branch`  Data object is being added
- `app/1` (Data Object Key): `branch/id`  Data object key is being added
- `app/1` (Action): `branch/create`  Action is being added
- `app/1` (Real Time Action Processing): `branch/create`  Real time action processing is being added
- `app/1` (Data Object): `task`  Data object is being added
- `app/1` (Data Object Key): `task/id`  Data object key is being added
- `app/1` (Action): `task/create`  Action is being added
- `app/1` (Real Time Action Processing): `task/create`  Real time action processing is being added
- `app/1` (Action): `task/update`  Action is being added
- `app/1` (Real Time Action Processing): `task/update`  Real time action processing is being added
