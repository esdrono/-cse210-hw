class Activity:
    def __init__(self, date, length_minutes):
        self.date = date
        self.length_minutes = length_minutes

    def get_distance(self):
        return 0

    def get_speed(self):
        return 0

    def get_pace(self):
        return 0

    def get_summary(self):
        return f"{self.date} {self.__class__.__name__} ({self.length_minutes} min) - Distance {self.get_distance():.1f} miles, Speed {self.get_speed():.1f} mph, Pace: {self.get_pace():.1f} min per mile"

class Running(Activity):
    def __init__(self, date, length_minutes, distance):
        super().__init__(date, length_minutes)
        self.distance = distance

    def get_distance(self):
        return self.distance

    def get_speed(self):
        return self.distance / (self.length_minutes / 60)

    def get_pace(self):
        return self.length_minutes / self.distance

class StationaryBicycles(Activity):
    def __init__(self, date, length_minutes, speed):
        super().__init__(date, length_minutes)
        self.speed = speed

    def get_speed(self):
        return self.speed

    def get_distance(self):
        return self.speed * (self.length_minutes / 60)

    def get_pace(self):
        return 60 / self.speed

class Swimming(Activity):
    def __init__(self, date, length_minutes, laps):
        super().__init__(date, length_minutes)
        self.laps = laps

    def get_distance(self):
        return self.laps * 50 / 1000

    def get_speed(self):
        return self.get_distance() / (self.length_minutes / 60)

    def get_pace(self):
        return 60 / self.get_speed()

# Create Activity instances
activity1 = Running("2023-11-03", 30, 3.0)
activity2 = StationaryBicycles("2023-11-04", 45, 15.0)
activity3 = Swimming("2023-11-05", 40, 25)

# Create a list of activities
activities = [activity1, activity2, activity3]

# Display activity summary
for activity in activities:
    print(activity.get_summary())
