class Comment:
    def __init__(self, commenter_name, comment_text):
        self.commenter_name = commenter_name
        self.comment_text = comment_text

class Video:
    def __init__(self, title, author, length):
        self.title = title
        self.author = author
        self.length = length
        self.comments = []

    def add_comment(self, commenter_name, comment_text):
        comment = Comment(commenter_name, comment_text)
        self.comments.append(comment)

    def get_num_comments(self):
        return len(self.comments)

# Create Video instances and add comments
video1 = Video("Video 1 Title", "Author 1", 600)
video1.add_comment("Commenter A", "This is a great video!")
video1.add_comment("Commenter B", "I learned a lot from this.")

video2 = Video("Video 2 Title", "Author 2", 480)
video2.add_comment("Commenter X", "Interesting content.")
video2.add_comment("Commenter Y", "I enjoyed it.")

# Put all videos in a list
video_list = [video1, video2]  

# Display video information and comments
for video in video_list:
    print("Title:", video.title)
    print("Author:", video.author)
    print("Length:", video.length, "seconds")
    print("Number of Comments:", video.get_num_comments())
    print("Comments:")
    for comment in video.comments:
        print("  Comment by:", comment.commenter_name)
        print("  Comment Text:", comment.comment_text)
    print()
