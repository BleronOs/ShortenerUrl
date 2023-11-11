import uuid

def generateUniqueShortText():
    short_text = str(uuid.uuid4())[:4] 
    return short_text