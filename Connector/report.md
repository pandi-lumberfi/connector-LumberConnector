# Metadata Report

Findings from the metadata extraction process.

## Breaking Changes

These changes to the Connector's metadata break how integrations could be leveraging the Connector. These changes are not safe to be applied to Xchange.

No breaking changes found.

## Non-Breaking Changes

These changes expand or maintain the Connector's metadata and are safe to be applied to Xchange.

- `app/1` (Action): `employees/create` `/properties/source_system` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/company_user_type` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/department` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/job_classification` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/job_level` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/union` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/employee_class` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/comp_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/job_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/workplaces` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/employee_type` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/department_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/department_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/branch_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/branch_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/employee_class_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/employee_class_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/job_classification_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/job_classification_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/company_id/#/AnyOf` Updated schema was changed to allow the types: Null,String
- `app/1` (Action): `employees/create` `/properties/user/#/AnyOf` Updated schema was changed to allow the types: Null,Object
- `app/1` (Action): `employees/create` `/required/company_id` Required property was removed from the new schema.
- `app/1` (Action): `employees/create` `/properties/source_system` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/company_user_type` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/department` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/job_classification` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/job_level` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/union` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/employee_class` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/comp_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/job_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/workplaces` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/create` `/properties/employee_type` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/department_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/department_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/branch_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/branch_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/employee_class_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/employee_class_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/job_classification_id` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/job_classification_code` Property added to the schema without being required.
- `app/1` (Action): `employees/create` `/properties/company_id/#/AnyOf` Updated schema was changed to allow the types: Null,String
- `app/1` (Action): `employees/create` `/properties/user/#/AnyOf` Updated schema was changed to allow the types: Null,Object
- `app/1` (Action): `employees/create` `/required/company_id` Required property was removed from the new schema.
- `app/1` (Action): `employees/update` `/properties/source_system` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/company_user_type` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/department` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/job_classification` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/job_level` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/union` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/employee_class` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/comp_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/job_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/workplaces` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/employee_type` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/department_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/department_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/branch_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/branch_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/employee_class_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/employee_class_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/job_classification_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/job_classification_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/company_id/#/AnyOf` Updated schema was changed to allow the types: Null,String
- `app/1` (Action): `employees/update` `/properties/user/#/AnyOf` Updated schema was changed to allow the types: Null,Object
- `app/1` (Action): `employees/update` `/required/company_id` Required property was removed from the new schema.
- `app/1` (Action): `employees/update` `/properties/source_system` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/company_user_type` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/department` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/job_classification` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/job_level` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/union` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/employee_class` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/comp_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/job_codes` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/workplaces` Property was removed, but schema allows additional properties.
- `app/1` (Action): `employees/update` `/properties/employee_type` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/department_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/department_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/branch_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/branch_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/employee_class_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/employee_class_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/job_classification_id` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/job_classification_code` Property added to the schema without being required.
- `app/1` (Action): `employees/update` `/properties/company_id/#/AnyOf` Updated schema was changed to allow the types: Null,String
- `app/1` (Action): `employees/update` `/properties/user/#/AnyOf` Updated schema was changed to allow the types: Null,Object
- `app/1` (Action): `employees/update` `/required/company_id` Required property was removed from the new schema.
