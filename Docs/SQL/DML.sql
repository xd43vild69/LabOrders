insert into Patient (FirstName, LastName, MedicalHistory, Gender, Telephone, EmergencyContactTelephone, BirthDay)
values ('Patient1', 'Gomez', 'Sin Historial', 'M', '3151515', '12335456', '2019-12-19')

insert into Patient (FirstName, LastName, MedicalHistory, Gender, Telephone, EmergencyContactTelephone, BirthDay)
values ('Patient2', 'Gomez', 'Sin Historial', 'M', '3151515', '12335456', '2019-12-19')

insert into OrderType (NameType) values ('MEDICAMENTO')
insert into OrderType (NameType) values ('CIRUGIA')
insert into OrderType (NameType) values ('TRATAMIENTO')

insert into OrderState (NameOrderState) values ('ORDENADO')
insert into OrderState (NameOrderState) values ('CANCELADO')
insert into OrderState (NameOrderState) values ('SUMINISTRADO')

insert into OrderPriority (NameOrderPriority) values ('ALTA')
insert into OrderPriority (NameOrderPriority) values ('MEDIA')
insert into OrderPriority (NameOrderPriority) values ('BAJA')