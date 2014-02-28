drop table kc_child_eventdetail;
drop table kc_child_detail;
drop table kc_event_type;
drop table kc_child_group;

create table kc_child_group (
id smallint primary key auto_increment, 
group_name varchar(128) not null
);

create table kc_event_type (
id smallint primary key auto_increment,
event_type enum ('nappy', 'feed', 'nap') not null,
UNIQUE (event_type)
);

create table kc_child_detail (
id int primary key auto_increment,
first_name varchar(128) not null,
last_name varchar(128) not null,
parent1_name varchar(128) not null,
parent2_name varchar(128),
date_of_birth date not null,
child_group_id smallint not null,
foreign key (child_group_id) references kc_child_group (id)
);

create table kc_child_eventdetail (
id int primary key auto_increment,
child_id int not null,
event_type_id smallint not null,
event_date date not null,
start_time time not null,
end_time time,
foreign key (child_id) references kc_child_detail (id),
foreign key (event_type_id) references kc_event_type (id)
);
