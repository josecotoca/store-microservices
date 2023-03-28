CREATE TABLE IF NOT EXISTS public.products
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    code text COLLATE pg_catalog."default" NOT NULL,
    name text COLLATE pg_catalog."default" NOT NULL,
    description text COLLATE pg_catalog."default",
    for_inventory boolean NOT NULL,
    for_sale boolean NOT NULL,
    price double precision NOT NULL,
    stock double precision NOT NULL,
    stock_pending_delivery double precision NOT NULL,
    created_at timestamp with time zone NOT NULL,
    updated_at timestamp with time zone,
    state boolean NOT NULL,
    CONSTRAINT "PK_products" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.products
    OWNER to postgres;

CREATE TABLE IF NOT EXISTS public.sales
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    invoice_name text COLLATE pg_catalog."default" NOT NULL,
    invoice_nit text COLLATE pg_catalog."default" NOT NULL,
    observation text COLLATE pg_catalog."default",
    date timestamp with time zone NOT NULL,
    delivered text COLLATE pg_catalog."default" NOT NULL,
    date_delivered timestamp with time zone,
    subtotal double precision NOT NULL,
    charge_tax double precision NOT NULL,
    total double precision NOT NULL,
    CONSTRAINT "PK_sales" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.sales
    OWNER to postgres;


CREATE TABLE IF NOT EXISTS public.sales_details
(
    id integer NOT NULL GENERATED BY DEFAULT AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
    sale_id integer NOT NULL,
    product_id integer NOT NULL,
    description text COLLATE pg_catalog."default" NOT NULL,
    quantity double precision NOT NULL,
    price double precision NOT NULL,
    subtotal double precision NOT NULL,
    charge_tax double precision NOT NULL,
    total double precision NOT NULL,
    CONSTRAINT "PK_sales_details" PRIMARY KEY (id),
    CONSTRAINT "FK_sales_details_sales_sale_id" FOREIGN KEY (sale_id)
        REFERENCES public.sales (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE CASCADE
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.sales_details
    OWNER to postgres;
-- Index: IX_sales_details_sale_id

-- DROP INDEX IF EXISTS public."IX_sales_details_sale_id";

CREATE INDEX IF NOT EXISTS "IX_sales_details_sale_id"
    ON public.sales_details USING btree
    (sale_id ASC NULLS LAST)
    TABLESPACE pg_default;