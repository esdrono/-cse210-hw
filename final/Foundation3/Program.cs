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

class Event:
    def __init__(self, title, description, date, time, address):
        self.title = title
        self.description = description
        self.date = date
        self.time = time
        self.address = address

    def get_standard_details(self):
        return f"Title: {self.title}\nDescription: {self.description}\nDate: {self.date}\nTime: {self.time}\nAddress: {self.address.get_full_address()}"

    def get_full_details(self):
        return self.get_standard_details()

    def get_short_description(self):
        return f"Type: {self.__class__.__name__}, Title: {self.title}, Date: {self.date}"

class Lecture(Event):
    def __init__(self, title, description, date, time, address, speaker, capacity):
        super().__init__(title, description, date, time, address)
        self.speaker = speaker
        self.capacity = capacity

    def get_full_details(self):
        return f"{super().get_full_details()}\nSpeaker: {self.speaker}\nCapacity: {self.capacity} attendees"

class Reception(Event):
    def __init__(self, title, description, date, time, address, rsvp_email):
        super().__init__(title, description, date, time, address)
        self.rsvp_email = rsvp_email

    def get_full_details(self):
        return f"{super().get_full_details()}\nRSVP Email: {self.rsvp_email}"

class OutdoorGathering(Event):
    def __init__(self, title, description, date, time, address, weather):
        super().__init__(title, description, date, time, address)
        self.weather = weather

    def get_full_details(self):
        return f"{super().get_full_details()}\nWeather: {self.weather}"

# Create Address instances
address1 = Address("123 Main St", "Anytown", "CA", "USA")
address2 = Address("456 Elm St", "Othercity", "NY", "Canada")

# Create Event instances
event1 = Lecture("Tech Talk", "A discussion on AI", "2023-10-30", "15:00", address1, "Dr. Smith", 50)
event2 = Reception("Networking Event", "Meet and greet", "2023-11-05", "18:30", address1, "rsvp@example.com")
event3 = OutdoorGathering("Picnic", "Casual get-together", "2023-11-15", "12:00", address2, "Sunny")

# Display event details
print("Event 1 - Standard Details:")
print(event1.get_standard_details())
print()

print("Event 2 - Full Details:")
print(event2.get_full_details())
print()

print("Event 3 - Short Description:")
print(event3.get_short_description())
