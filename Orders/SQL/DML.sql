insert into Patient (FirstName, LastName, MedicalHistory, Gender, Telephone, EmergencyContactTelephone, BirthDay)
values ('David', 'Gomez', 'Sin Historial', 'M', '3151515', '12335456', '2019-12-19')

insert into Patient (FirstName, LastName, MedicalHistory, Gender, Telephone, EmergencyContactTelephone, BirthDay)
values ('Ana', 'Gomez', 'Sin Historial', 'M', '3151515', '12335456', '2019-12-19')

insert into OrderType (NameType) values ('MEDICAMENTO')
insert into OrderType (NameType) values ('CIRUGIA')
insert into OrderType (NameType) values ('TRATAMIENTO')

insert into OrderState (NameOrderState) values ('ORDENADO')
insert into OrderState (NameOrderState) values ('CANCELADO')
insert into OrderState (NameOrderState) values ('SUMINISTRADO')