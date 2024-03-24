CREATE TABLE products (
    product_id BIGSERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    price NUMERIC NOT NULL,
    UNIQUE(name)
);

CREATE TABLE shops (
    shop_id BIGSERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT,
    UNIQUE(name) 
);

CREATE TABLE shop_products (
    shop_id BIGINT NOT NULL REFERENCES shops(shop_id),
    product_id BIGINT NOT NULL REFERENCES products(product_id),
    PRIMARY KEY (shop_id, product_id)
);