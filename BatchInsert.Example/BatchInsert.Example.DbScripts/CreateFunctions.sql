CREATE OR REPLACE FUNCTION insert_shops_and_products(
	shops shop_type[], 
	products product_type[]
)
returns void
language plpgsql AS $$
BEGIN
    
	insert into public.shops (
		"name",
		description
	)
	select 
		s.shop_name,
		s.description
	from unnest(shops) s
	on conflict (name)
	do nothing;

	insert into public.products (
		"name",
		price
	)
	select
		p.product_name,
		p.price
	from unnest(products) p
	on conflict (name)
	do nothing;

	insert into public.shop_products (
		shop_id,
		product_id
	)
	select
		s.shop_id,
		p1.product_id
	from unnest(products) p
	inner join public.shops s on s.name = p.shop_name
	inner join public.products p1 on p1.name = p.product_name
	on conflict (shop_id, product_id)
	do nothing;
	
END;
$$;
