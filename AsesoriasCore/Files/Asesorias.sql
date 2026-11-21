create database Asesorias;
use Asesorias;

create table Alumno(
id int not null primary key auto_increment,
nombre varchar(50) not null,
matricula varchar(12) not null,
contrasenia varchar(60) not null
);

create table Asesoria(
id int not null primary key auto_increment,
id_tutor int not null,
materia varchar(80) not null,
descripcion varchar(200) not null,
fecha date not null,
hora int not null, -- formate 24 hrs,
lugar varchar(150) not null,
cupo int not null,
estado varchar(20) not null,
constraint fkAlumnoAsesoria foreign key(id_tutor) references Alumno(id)
);

create table inscripcion(
id int not null primary key auto_increment,
id_alumno int not null,
id_asesoria int not null,
estado varchar(20) not null,
constraint FkInscripcionAlumno foreign key (id_alumno) references Alumno(id),
constraint FkInscripcionAsesoria foreign key (id_asesoria) references Asesoria(id)
);