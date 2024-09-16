CREATE DATABASE tienda;
USE DATABASE tienda;

DROP TABLE if EXISTS productos;
CREATE TABLE productos(
idProducto INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
nombre VARCHAR(100),
descripcion VARCHAR(255),
precio DOUBLE,
created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
updated_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

INSERT INTO productos (nombre, descripcion, precio)
VALUES
  ('Smartphone X', 'Teléfono móvil de alta gama con pantalla OLED y cámara de 108MP.', 999.99),
  ('Camiseta de algodón', 'Camiseta básica de algodón orgánico en varios colores.', 19.99),
  ('Zapatos deportivos', 'Zapatillas de running para hombre, diseño ligero y cómodo.', 79.99),
  ('Cafetera espresso', 'Cafetera espresso automática con molinillo integrado.', 299.99),
  ('Libro de cocina', 'Recetas saludables y deliciosas para toda la familia.', 14.99),
  ('Silla de oficina ergonómica', 'Silla de oficina ajustable con respaldo lumbar.', 199.99),
  ('Bicicleta de montaña', 'Bicicleta de montaña de aluminio con suspensión delantera.', 499.99),
  ('Consola de videojuegos', 'Consola de última generación con los juegos más populares.', 399.99),
  ('Smartwatch', 'Reloj inteligente con monitor de frecuencia cardíaca y GPS.', 249.99),
  ('Auriculares inalámbricos', 'Auriculares inalámbricos con cancelación de ruido.', 99.99);

DELIMITER //
CREATE PROCEDURE p_modificarProducto
(
	IN _idProducto INT,
	IN _nombre VARCHAR(100),
	IN _descripcion VARCHAR(255),
	IN _costo DOUBLE
)
BEGIN
	
	UPDATE productos SET nombre = _nombre, descripcion = _descripcion, costo = _costo WHERE idProducto = _idProducto;
	
END //
DELIMITER ;

CALL p_modificarProducto(11, 'Google Pixel 8', 'Telefono diseñado por Google.', 699.99);

