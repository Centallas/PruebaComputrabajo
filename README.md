# PruebaComputrabajo

Para compilar este proyecto

SQL

1. Crear la bd en SQL o usar una ya creada
2. Correr los scripts en el siguiente orden
    a. CreateEmployeeTable.sql
    b. CreateEmployeeSP.sql

Code

1. Download source code 
2. Set Web Api as started project
2. Run the service in Visual Studio 2019 o superior

Postman 

1. Insertar registros 
   POST  https://.../api/redarbor/
    
    NOTA:   ES IMPORTANTE QUE EL JASON QUE SE ENVIA AL INSERTAR ESTE BIEN ESTRUCTURADO ****
    
    - En el body agregar:
      
       {
        "id": 0,
        "companyId": "1",
        "createdOn": "2020-01-03T17:16:40",
        "deletedOn": "2020-01-03T17:16:40",
        "email": "testDelete@test.tmp",
        "fax": "000.000.000",
        "testName": "testDelete",
        "lastLogin": "2020-01-06T17:16:40",
        "password": "testDelete",
        "portalId": "1",
        "roleId": "4",
        "statusId": "2",
        "telephone": "000.000.000",
        "updatedOn": "2020-01-03T17:16:40",
        "username": "testDelete",
        "type": "insert"
      }
      
      Esta es la estructura 
     - SEND 
     
 2. GET https://.../api/redarbor/
     (get all employees)
     
 3. GET https://.../api/redarbor/1
        (get employee by id)
        
 4.  PUT https://.../api/redarbor/1
        (edit employee)
         NOTA:   ES IMPORTANTE QUE EL JSON QUE SE ENVIA AL ACTUALIZAR ESTE BIEN ESTRUCTURADO ****

5.   DELETE   https://.../api/redarbor/1
        (Remove a record)
      
    


