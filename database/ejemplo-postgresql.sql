-- Ejecutar en la base FundamentosCSharp. No elimina tablas ni registros.
-- El nombre sin comillas se guarda en minusculas: coincide con el SELECT de C#.
BEGIN;

CREATE TABLE IF NOT EXISTS cervezas
(
    id integer GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nombre text NOT NULL CHECK (length(trim(nombre)) > 0),
    marca text NOT NULL CHECK (length(trim(marca)) > 0),
    alcohol integer NOT NULL CHECK (alcohol BETWEEN 0 AND 100),
    cantidad integer NOT NULL CHECK (cantidad >= 0)
);

-- Solo insertamos cada ejemplo si todavia no existe con ese nombre y marca.
INSERT INTO cervezas (nombre, marca, alcohol, cantidad)
SELECT 'Cerveza rubia de ejemplo', 'Marca de practica', 5, 330
WHERE NOT EXISTS (
    SELECT 1 FROM cervezas
    WHERE nombre = 'Cerveza rubia de ejemplo' AND marca = 'Marca de practica'
);

INSERT INTO cervezas (nombre, marca, alcohol, cantidad)
SELECT 'Cerveza sin alcohol de ejemplo', 'Marca de practica', 0, 500
WHERE NOT EXISTS (
    SELECT 1 FROM cervezas
    WHERE nombre = 'Cerveza sin alcohol de ejemplo' AND marca = 'Marca de practica'
);

COMMIT;
