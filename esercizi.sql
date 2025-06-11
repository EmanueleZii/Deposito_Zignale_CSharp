/*
SELECT customer.first_name, address.address
FROM customer
JOIN address ON address.address_id = customer.address_id
join country on country.country_id = address.address_id;

SELECT customer.first_name,  staff.first_name
FROM customer
JOIN staff ON staff.staff_id = customer.customer_id
join rental on rental.customer_id = customer.customer_id and rental.staff_id = staff.staff_id

select title, length from film 

select title, length from film  where length >= 120;

select first_name,last_name, address_id from customer where address_id = 312;

select rental_id, amount from payment where amount= 5.99;

select first_name,last_name, address_id from customer where address_id = 312 or address_id = 459;

select title, rating, length from film where length >=90 and rating="PG";

select title, rating, length from film where length <=80 or length >=180;

select title, rating, length from film where rating = "R";

select rental_id, amount from payment where amount >= 2.00 and amount<= 5.00;

select title, rating, length from film where rating between "PG" and "R";

select *from film where rating ="PG" or rating ="G" or rating ="PG-13";

select *from film where title like "THE%";

select * from customer where first_name like "A%";

select * from rental where return_date is null;

WHERE rating = "G" and 
rental_rate = 0.99 OR rental_rate = 4.99;

SELECT title, length
FROM film
ORDER BY length DESC
LIMIT 10;

SELECT first_name, last_name, create_date
FROM customer
ORDER BY create_date DESC
LIMIT 5;

SELECT DISTINCT rating
FROM film;
SELECT DISTINCT amount
FROM payment
ORDER BY amount DESC;

SELECT title, length
FROM film
WHERE rating = 'PG-13'
ORDER BY length DESC
LIMIT 3;

SELECT title, LENGTH(title) AS title_length
FROM film;

SELECT UPPER(first_name) AS first_name_upper,
       UPPER(last_name) AS last_name_upper
FROM customer;

SELECT LOWER(title) AS title_lower
FROM film
LIMIT 10;

SELECT CONCAT(title, ' (', rating, ')') AS titolo_completo
FROM film;

SELECT LEFT(title, 10) AS primi_10_caratteri
FROM film;

SELECT RIGHT(title, 5) AS ultimi_5_caratteri
FROM film
LIMIT 10;

SELECT LEFT(last_name, 3) AS abbreviazione_cognome
FROM customer;

SELECT
SUBSTRING_INDEX(title, ' ', 1) AS prima_parola,
COUNT(*) AS occorrenze
FROM
film
GROUP BY
prima_parola
ORDER BY
occorrenze DESC;

SELECT 
    customer_id,
    first_name,
    last_name,
    create_date,
    CURDATE() AS data_attuale
FROM customer;

SELECT 
    customer_id,
    first_name,
    last_name,
    create_date,
    DATEDIFF(CURDATE(), create_date) AS giorni_passati
FROM customer;

SELECT 
    customer_id,
    first_name,
    last_name,
    YEAR(create_date) AS anno_creazione
FROM customer;

SELECT 
    rental_id,
    customer_id,
    rental_date
FROM rental
WHERE YEAR(rental_date) = 2005;

SELECT 
    customer_id,
    first_name,
    last_name,
    create_date,
    DATEDIFF(NOW(), create_date) AS giorni_registrato
FROM customer
ORDER BY customer_id
LIMIT 10;


SELECT 
    rating, 
    COUNT(*) AS totale_film
FROM film
GROUP BY rating;

SELECT 
    rating,
    AVG(length) AS durata_media
FROM film
GROUP BY rating;

SELECT 
    rating, 
    COUNT(*) AS totale_film
FROM film
GROUP BY rating;

SELECT 
    rating, 
    AVG(length) AS durata_media
FROM film
GROUP BY rating;

SELECT 
    customer_id, 
    COUNT(*) AS numero_pagamenti
FROM payment
GROUP BY customer_id;

SELECT 
    customer_id, 
    SUM(amount) AS totale_pagato
FROM payment
GROUP BY customer_id;

SELECT 
    length, 
    COUNT(*) AS numero_film
FROM film
GROUP BY length
ORDER BY length ASC;
SELECT 
    rating, 
    AVG(length) AS durata_media
FROM film
GROUP BY rating
HAVING AVG(length) > 100;

SELECT 
    customer_id, 
    SUM(amount) AS totale_pagato
FROM payment
GROUP BY customer_id
HAVING SUM(amount) > 100;

SELECT 
    rating, 
    COUNT(*) AS numero_film
FROM film
GROUP BY rating
HAVING COUNT(*) >= 50;

SELECT 
    rating, 
    ROUND(AVG(length), 1) AS durata_media
FROM film
GROUP BY rating;

SELECT 
    customer_id, 
    COUNT(*) AS numero_pagamenti
FROM payment
GROUP BY customer_id
HAVING COUNT(*) > 10;

SELECT count(actor.id), c.name
FROM film AS f
JOIN actor AS ac ON f.film_id = ac.actor_id
GROUP BY ac.actor_id, c.name 
ORDER BY c.name DESC;


SELECT actor.first_name, actor.last_name, COUNT(film.film_id) as numero
FROM actor
JOIN film_actor ON actor.actor_id = film_actor.actor_id
JOIN film ON film_actor.film_id = film.film_id
GROUP BY actor.actor_id
HAVING numero>35;

*/
/*
SELECT
    film.title AS film_title,
    category.name AS category_name,
	SUM(payment.amount) AS total_spent_on_film
FROM
    film 
JOIN
    film_category ON film.film_id = film_category.film_id
JOIN
    category ON film_category.category_id = category.category_id
JOIN
    actor ON film_actor.actor_id = actor.actor_id
GROUP BY
    film.film_id, film.title, category.name
ORDER BY
    film.title;
    */
/*
SELECT
    f.title AS film_title,
    c.name AS category_name,
    SUM(p.amount) AS total_spent_on_film
FROM
    film AS f
JOIN
    film_category AS fc ON f.film_id = fc.film_id
JOIN
    category AS c ON fc.category_id = c.category_id
JOIN
    inventory AS i ON f.film_id = i.film_id
JOIN
    rental AS r ON i.inventory_id = r.inventory_id
JOIN
    payment AS p ON r.rental_id = p.rental_id
GROUP BY
    f.film_id, f.title, c.name
ORDER BY
    f.title;
    
    
    SELECT
    c.customer_id,
    c.first_name,
    c.last_name,
    COUNT(r.rental_id) AS numero_noleggi_totali,
    SUM(p.amount) AS spesa_totale
FROM
    customer AS c
JOIN
    rental AS r ON c.customer_id = r.customer_id
JOIN
    payment AS p ON r.rental_id = p.rental_id
GROUP BY
    c.customer_id, c.first_name, c.last_name
HAVING
    COUNT(r.rental_id) > 20
ORDER BY
    spesa_totale DESC;
    
    SELECT
    c.name AS category_name,
    COUNT(r.rental_id) AS total_rentals,
    AVG(film_rentals.num_rentals) AS average_rentals_per_film_in_category
FROM
    category AS c
JOIN
    film_category AS fc ON c.category_id = fc.category_id
JOIN
    film AS f ON fc.film_id = f.film_id
JOIN
    inventory AS i ON f.film_id = i.film_id
JOIN
    rental AS r ON i.inventory_id = r.inventory_id
JOIN (
    SELECT
        f.film_id,
        COUNT(r.rental_id) AS num_rentals
    FROM
        film AS f
    JOIN
        inventory AS i ON f.film_id = i.film_id
    JOIN
        rental AS r ON i.inventory_id = r.inventory_id
    GROUP BY
        f.film_id
) AS film_rentals ON f.film_id = film_rentals.film_id
GROUP BY
    c.name
HAVING
    COUNT(r.rental_id) >= 50
ORDER BY
    average_rentals_per_film_in_category DESC;
    
    SELECT
    a.actor_id,
    a.first_name,
    a.last_name,
    COUNT(DISTINCT fa.film_id) AS numero_film_a_catalogo,
    COUNT(r.rental_id) AS totale_noleggi_film_recitati
FROM
    actor AS a
JOIN
    film_actor AS fa ON a.actor_id = fa.actor_id
JOIN
    film AS f ON fa.film_id = f.film_id
JOIN
    inventory AS i ON f.film_id = i.film_id
LEFT JOIN
    rental AS r ON i.inventory_id = r.inventory_id
GROUP BY
    a.actor_id, a.first_name, a.last_name
HAVING
    COUNT(DISTINCT fa.film_id) >= 10
ORDER BY
    totale_noleggi_film_recitati DESC;
    
select
concat(a.first_name, ' ', a.last_name) as NomeCognome,
COUNT(distinct f.film_id) as NumFilm,
COUNT(r.rental_id) as NumRent
from actor a
join film_actor fa on fa.actor_id = a.actor_id
join film f on f.film_id = fa.film_id
join inventory i on i.film_id = f.film_id
join rental r on r.inventory_id = i.inventory_id
group by NomeCognome
HAVING NumFilm >= 10
order by NumRent DESC;
*/
/*
SELECT
c.name, SUM(p.amount) / COUNT(distinct f.film_id) AS media_spesa
FROM
category AS c
JOIN
film_category AS fc ON c.category_id = fc.category_id
JOIN
film AS f ON f.film_id = fc.film_id
JOIN
inventory AS i ON i.film_id = f.film_id
JOIN
rental AS r ON i.inventory_id = r.inventory_id
JOIN
payment AS p ON r.rental_id = p.rental_id
GROUP BY
c.name
ORDER BY
media_spesa DESC;
*/
/*

SELECT c.customer_id, c.first_name, c.last_name,
       COUNT(DISTINCT a.actor_id) AS total_attori
FROM customer AS c
JOIN rental AS r ON c.customer_id = r.customer_id
JOIN inventory AS i ON r.inventory_id = i.inventory_id
JOIN film AS f ON i.film_id = f.film_id
JOIN film_actor AS fa ON f.film_id = fa.film_id
JOIN actor AS a ON fa.actor_id = a.actor_id
GROUP BY c.customer_id, c.first_name, c.last_name;

INSERT INTO actor (first_name, last_name, last_update)
VALUES ('Mario', 'Rossi', NOW());

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
JOIN film_actor fa ON a.actor_id = fa.actor_id
JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
LEFT JOIN film_actor fa ON a.actor_id = fa.actor_id
LEFT JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';

*/
/*
SELECT
    f.film_id,
    f.title,
    f.rental_rate
FROM
    film AS f
WHERE
    f.rental_rate > (SELECT AVG(rental_rate) FROM film);
    
SELECT DISTINCT
    a.first_name,
    a.last_name
FROM
    actor AS a
WHERE
    a.actor_id IN (
        SELECT DISTINCT fa.actor_id
        FROM film_actor AS fa
        JOIN film_category AS fc ON fa.film_id = fc.film_id
        JOIN category AS c ON fc.category_id = c.category_id
        WHERE c.name = 'Action'
    )
ORDER BY
    a.last_name, a.first_name;
    
    
    /*soluzione esercizio 1
SELECT
    f.title
FROM
    film AS f
JOIN
    film_actor AS fa ON f.film_id = fa.film_id
GROUP BY
    f.film_id, f.title
    HAVING
    COUNT(fa.actor_id) = (
        SELECT
            COUNT(fa_ad.actor_id)
        FROM
            film AS f_ad
            JOIN
            film_actor AS fa_ad ON f_ad.film_id = fa_ad.film_id
        WHERE
            f_ad.title = 'ACADEMY DINOSAUR'
        GROUP BY
            f_ad.film_id
    )
AND
    f.title <> 'ACADEMY DINOSAUR'; -- Esclude il film "ACADEMY DINOSAUR" stesso dal risultato
    
 /* soluzione esercizio 2    
SELECT c.name, COUNT(fc.film_id) AS num_film
FROM category c
JOIN film_category fc ON c.category_id = fc.category_id
GROUP BY c.category_id
HAVING COUNT(fc.film_id) > (
	SELECT AVG(film_count)
	FROM (
		SELECT COUNT(*) AS film_count
		FROM film_category
		GROUP BY category_id
	) AS sub
);

SELECT
    c.customer_id,
    c.first_name,
    c.last_name,
    SUM(p.amount) AS total_spent
FROM
    customer AS c
JOIN
    payment AS p ON c.customer_id = p.customer_id
GROUP BY
    c.customer_id, c.first_name, c.last_name
HAVING
    SUM(p.amount) > (
    SELECT AVG(total_spent) 
    FROM (
    SELECT SUM(amount) AS total_spent 
    FROM payment GROUP BY customer_id) AS customer_spending
    );
*/    
use sakila;

/*
Trova i titoli dei film e il loro rental_rate 
che hanno un costo di noleggio (rental_rate)
 superiore al rental_rate medio di tutti i film che appartengono
 alla stessa categoria di rating
 */
 
 SELECT
    f.title,
    f.rental_rate,
    f.rating
FROM
    film AS f
WHERE
    f.rental_rate > (
        SELECT
            AVG(f2.rental_rate)
        FROM
            film AS f2
        WHERE
            f2.rating = f.rating
    )
ORDER BY
    f.rating, f.title;
    /* fine mio esercizio*/
    
SELECT
    f.title,
    f.length,
    c.name AS category_name
FROM
    film AS f
JOIN
    film_category AS fc ON f.film_id = fc.film_id
JOIN
    category AS c ON fc.category_id = c.category_id
WHERE
    f.length = (
        SELECT
            MAX(f2.length)
        FROM
            film AS f2
        JOIN
            film_category AS fc2 ON f2.film_id = fc2.film_id
        WHERE
            fc2.category_id = fc.category_id
    )
ORDER BY
    c.name, f.title;
    
SELECT
    a.first_name,
    a.last_name,
    COUNT(r.rental_id) AS total_rentals_by_actor
FROM
    actor AS a
JOIN
    film_actor AS fa ON a.actor_id = fa.actor_id
JOIN
    inventory AS i ON fa.film_id = i.film_id
JOIN
    rental AS r ON i.inventory_id = r.inventory_id
GROUP BY
    a.actor_id, a.first_name, a.last_name
HAVING
    COUNT(r.rental_id) < (
        SELECT
            AVG(actor_rentals.num_rentals)
        FROM
            (
                SELECT
                    a2.actor_id,
                    COUNT(r2.rental_id) AS num_rentals
                FROM
                    actor AS a2
                JOIN
                    film_actor AS fa2 ON a2.actor_id = fa2.actor_id
                JOIN
                    inventory AS i2 ON fa2.film_id = i2.film_id
                JOIN
                    rental AS r2 ON i2.inventory_id = r2.inventory_id
                GROUP BY
                    a2.actor_id
            ) AS actor_rentals
    )
ORDER BY
    total_rentals_by_actor DESC, a.last_name, a.first_name;
