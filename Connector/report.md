# Metadata Report

Findings from the metadata extraction process.

## Breaking Changes

These changes to the Connector's metadata break how integrations could be leveraging the Connector. These changes are not safe to be applied to Xchange.

No breaking changes found.

## Non-Breaking Changes

These changes expand or maintain the Connector's metadata and are safe to be applied to Xchange.

- Connector (Details):  Name will be changing
- `customAuth` (Connection Definition):  Connection definition property 'apiKey' will now be sensitive
- `customAuth` (Connection Definition):  Connection definition property 'apiSecretKey' will now be sensitive
- `app/1` (Real Time Action Processing): `employees/create`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `employees/create`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `employees/update`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `employees/update`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `project/create`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `project/create`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `project/update`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `project/update`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `cost-code/create`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `cost-code/create`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `cost-code/update`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `cost-code/update`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `cost-type/create`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `cost-type/create`  Divider limit will change from  to 10
- `app/1` (Real Time Action Processing): `cost-type/update`  Parallel limit will change from  to 5
- `app/1` (Real Time Action Processing): `cost-type/update`  Divider limit will change from  to 10
