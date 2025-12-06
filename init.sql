CREATE TABLE dish(
    id BIGINT PRIMARY KEY,
    name VARCHAR(255),
    price DOUBLE PRECISION
);

CREATE TABLE ingredient(
    id BIGINT PRIMARY KEY,
    name VARCHAR(255)
);

CREATE TABLE dish_ingredient(
    dish_id BIGINT REFERENCES dish(id),
    ingredient_id BIGINT REFERENCES ingredient(id),
    PRIMARY KEY (dish_id, ingredient_id)
);