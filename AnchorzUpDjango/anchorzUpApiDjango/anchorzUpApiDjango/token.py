from django.db import models
import uuid

class TokenIDField(models.CharField):
    def __init__(self, *args, **kwargs):
         kwargs['max_length'] = 255
         kwargs['unique'] = True
         kwargs['default'] = uuid.uuid4
         super().__init__(*args, **kwargs)