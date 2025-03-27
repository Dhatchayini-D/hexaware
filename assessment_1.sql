create database test;
use test;

create table pets (pet_id int primary key,name varchar(50) ,
age int,breed varchar(50) ,type varchar(50) , 
available_for_adoption bit, )

create table shelters(shelter_id int primary key,
name varchar(50),location varchar(50))

create table donations (donation_id int primary key,
donor_name varchar(50) ,donation_type varchar(50),
donation_amount decimal(10,2),donation_item varchar(50),
donation_date datetime)

create table adoptionevents (event_id int primary key ,
event_name varchar(50),even_date datetime ,location varchar(50))


create table participants (participant_id int primary key,
participant_name varchar(50),participant_type varchar(50),
event_id int, foreign key(event_id) references adoptionevents(event_id))


insert into pets values 
(1,'baby',1,'goldenretriever','dog', 1),
(2,'bob',2,'lab','dog', 0),
(3,'jully',3,'country_dog','dog', 1),
(4,'alice',4,'beagle','dog', 0),
(5,'coco',5,'pomeranian','dog', 1),
(6,'lilly',6,'persian','cat', 0),
(7,'rose',7,'begal','cat', 1),
(8,'brownie',8,'sphynx','cat', 0),
(9,'max',8,'siamese','cat', 1),
(10,'puppy',10,'begalll','cat', 0);


insert into shelters values
(1, 'Happy Tails Shelter', 'New York, NY'),
(2, 'Paws Haven', 'Los Angeles, CA'),
(3, 'Furry Friends Rescue', 'Chicago, IL'),
(4, 'Whisker Warriors', 'Houston, TX'),
(5, 'Tail Waggers Home', 'Miami, FL'),
(6, 'Purrfect Pals', 'Dallas, TX'),
(7, 'Fuzzy Haven', 'Seattle, WA'),
(8, 'Hope for Paws', 'Boston, MA'),
(9, 'Paw Prints Rescue', 'San Diego, CA'),
(10, 'Forever Home', 'San Francisco, CA');

drop table donations;
insert into donations values
(1, 'John Doe', 'Cash', 100.00,' toys', '2025-03-01 10:00:00'),
(2, 'Jane Smith', 'Item', 200.00, 'Dog Food', '2025-03-02 11:30:00'),
(3, 'Alice Johnson', 'Cash', 200.50,'litter', '2025-03-03 14:00:00'),
(4, 'Bob Brown', 'Item',300.00, 'CatToys', '2025-03-04 09:15:00'),
(5, 'Eve White', 'Cash', 150.75,'food', '2025-03-05 16:45:00'),
(6, 'Charlie Green', 'Item', 1.00, 'PetBeds', '2025-03-06 12:20:00'),
(7, 'Diana Black', 'Cash', 75.00,'beds', '2025-03-07 13:50:00'),
(8, 'Edward Blue', 'Item',900.00, 'Leashes & Collars', '2025-03-08 15:10:00'),
(9, 'Grace Yellow', 'Cash', 300.00,'cute toys', '2025-03-09 17:25:00'),
(10, 'Henry Orange', 'Item', 400.00, 'Cat Litter', '2025-03-10 10:40:00');

insert into adoptionevents values
(1, 'Spring Adoption Fair', '2025-04-01 09:00:00', 'Central Park, NY'),
(2, 'Paws for Love', '2025-04-15 10:30:00', 'Los Angeles Community Center'),
(3, 'Furry Friends Meet', '2025-05-01 12:00:00', 'Chicago Pet Expo'),
(4, 'Home for Paws', '2025-05-10 14:00:00', 'Houston Animal Shelter'),
(5, 'Adopt & Save', '2025-06-05 11:00:00', 'Miami Fairgrounds'),
(6, 'Forever Home Event', '2025-06-20 15:30:00', 'Dallas Pet Center'),
(7, 'Pets & People', '2025-07-03 09:45:00', 'Seattle Animal Rescue'),
(8, 'Find a Friend', '2025-07-18 13:15:00', 'Boston Pet Lovers Expo'),
(9, 'Give Love, Get Love', '2025-08-10 10:00:00', 'San Diego Adoption Center'),
(10, 'Hope & Homes', '2025-08-25 16:00:00', 'San Francisco Humane Society');


insert into Participants values
(1, 'Happy Tails Shelter', 'Shelter', 1),
(2, 'Paws Haven', 'Shelter', 2),
(3, 'Furry Friends Rescue', 'Shelter', 3),
(4, 'Whisker Warriors', 'Shelter', 4),
(5, 'Tail Waggers Home', 'Shelter', 5),
(6, 'John Doe', 'Adopter', 6),
(7, 'Jane Smith', 'Adopter', 7),
(8, 'Alice Johnson', 'Adopter', 8),
(9, 'Bob Brown', 'Adopter', 9),
(10, 'Eve White', 'Adopter', 10);


----Write an SQL query that retrieves a list of available pets (those marked as available for adoption)
---from the "Pets" table. Include the pet's name, age, breed, and type in the result set. Ensure that
----the query filters out pets that are not available for adoption.

select name, age, breed, type
from pets 
where available_for_adoption = 0;

-----Write an SQL query that retrieves the names of participants (shelters and adopters) registered
----for a specific adoption event. Use a parameter to specify the event ID. Ensure that the query
----joins the necessary tables to retrieve the participant names and types.

select participant_name,participant_type 
from participants
join adoptionevents on participants.event_id=adoptionevents.event_id
where participants.event_id=adoptionevents.event_id;

---Create a stored procedure in SQL that allows a shelter to update its information (name and
----location) in the "Shelters" table. Use parameters to pass the shelter ID and the new information.
----Ensure that the procedure performs the update and handles potential errors, such as an invalid
-----shelter ID.




---------Write an SQL query that calculates and retrieves the total donation amount for each shelter (by
---shelter name) from the "Donations" table. The result should include the shelter name and the
-----total donation amount. Ensure that the query handles cases where a shelter has received no
----donations.


select s.name as sheltername, 
coalesce(sum(d.donation_amount), 0) as totaldonation
from shelters s
left join donations d on s.shelter_id = d.shelter_id
group by s.name;



-----Write an SQL query that retrieves the names of pets from the "Pets" table that do not have an
------owner (i.e., where "OwnerID" is null). Include the pet's name, age, breed, and type in the result
----set.



alter table pets add owner_id int null;

select name, age, breed, type
from pets
where owner_id IS NULL;


---Write an SQL query that retrieves the total donation amount for each month and year (e.g.,
---January 2023) from the "Donations" table. The result should include the month-year and the
----corresponding total donation amount. Ensure that the query handles cases where no donations
----were made in a specific month-year.
select format(donation_date ,'yyyy-MM') as month_year,
sum(donation_amount) as total_donation
from donations
group by format(donation_date,'yyyy-MM');


-------Retrieve a list of distinct breeds for all pets that are either aged between 1 and 3 years or older
----than 5 years.

select distinct breed 
from pets 
where age between 1 and 3 or age > 5;



---------Retrieve a list of pets and their respective shelters where the pets are currently available for
------adoption.
select pets.name as petname, shelters.name as sheltername
from pets 
join participants pt on pets.pet_id = pt.participant_id
join shelters  on pt.event_id = shelters.shelter_id
WHERE pets.available_for_adoption = 1;

-----Find the total number of participants in events organized by shelters located in specific city.
----Example: City=Chennai
select count(*) as total_participants
from participants p
join adoptionevents ae on p.event_id = ae.event_id
join shelters s on ae.location = s.location
where s.location = 'central park';


-------Retrieve a list of unique breeds for pets with ages between 1 and 5 years.
select distinct breed from pets where age between 1 and 5;

------Find the pets that have not been adopted by selecting their information from the 'Pet' table.

select * 
from pets 
where available_for_adoption = 0;

------Retrieve the names of all adopted pets along with the adopter's name from the 'Adoption' and
-----'User' tables.

select p.name as pet_name, pt.participant_name as adopter_name
from pets p
join participants pt on p.pet_id = pt.participant_id
where pt.participant_type = 'Adopter';

---------------------------------------------------------------------------------
drop table pets;
drop table shelters;
alter table pets
add shelter_id int;

alter table shelters
drop constraint shelter_id;
add constraint fk_shelter foreign key (shelter_id) references shelters(shelter_id);




---- Retrieve a list of all shelters along with the 
-----count of pets currently available for adoption in each
---shelter.
 SELECT s.name AS shelter_name, COUNT(p.pet_id) AS available_pets
FROM shelters s
LEFT JOIN pets p ON s.shelter_id = p.shelter_id AND p.available_for_adoption = 1
GROUP BY s.shelter_id, s.name;























