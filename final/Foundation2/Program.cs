class Address:
    def __init__(self, street, city, state, country):
        self.street = street
        self.city = city
        self.state = state
        self.country = country

    def is_usa(self):
        return self.country.lower() == "usa"

    def get_full_address(self):
        return f"{self.street}, {self.city}, {self.state}, {self.country}"

class Product:
    def __init__(self, name, product_id, price, quantity):
        self.name = name
        self.product_id = product_id
        self.price = price
        self.quantity = quantity

    def get_total_price(self):
        return self.price * self.quantity

class Customer:
    def __init__(self, name, address):
        self.name = name
        self.address = address

    def is_usa_customer(self):
        return self.address.is_usa()

class Order:
    def __init__(self, customer, products):
        self.customer = customer
        self.products = products

    def calculate_total_cost(self):
        total_price = sum(product.get_total_price() for product in self.products)
        if self.customer.is_usa_customer():
            shipping_cost = 5
        else:
            shipping_cost = 35
        return total_price + shipping_cost

    def get_packing_label(self):
        packing_label = f"Packing Label\nCustomer: {self.customer.name}\nProducts:\n"
        for product in self.products:
            packing_label += f"- {product.name}, Product ID: {product.product_id}\n"
        return packing_label

    def get_shipping_label(self):
        shipping_label = f"Shipping Label\nCustomer: {self.customer.name}\nAddress: {self.customer.address.get_full_address()}"
        return shipping_label

# Create Address instances
address1 = Address("123 Main St", "Anytown", "CA", "USA")
address2 = Address("456 Elm St", "Othercity", "NY", "Canada")

# Create Product instances
product1 = Product("Product A", "A123", 10.99, 2)
product2 = Product("Product B", "B456", 5.99, 3)
product3 = Product("Product C", "C789", 15.49, 1)

# Create Customer instances
customer1 = Customer("Alice", address1)
customer2 = Customer("Bob", address2)

# Create Order instances
order1 = Order(customer1, [product1, product2])
order2 = Order(customer2, [product2, product3])

# Calculate and display order information
total_cost1 = order1.calculate_total_cost()
packing_label1 = order1.get_packing_label()
shipping_label1 = order1.get_shipping_label()

total_cost2 = order2.calculate_total_cost()
packing_label2 = order2.get_packing_label()
shipping_label2 = order2.get_shipping_label()

print("Order 1 Total Cost:", total_cost1)
print(packing_label1)
print(shipping_label1)

print("Order 2 Total Cost:", total_cost2)
print(packing_label2)
print(shipping_label2)
