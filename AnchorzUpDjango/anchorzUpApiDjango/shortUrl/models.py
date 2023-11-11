from django.db import models
from anchorzUpApiDjango.token import TokenIDField
# Create your models here.
class ShortUrl(models.Model):
    id = TokenIDField(primary_key=True)
    originalUrl = models.TextField()
    shortAlias = models.CharField(max_length=60)
    created = models.DateTimeField(auto_now=True)
    expirationDateTime = models.DateTimeField(null=True, blank=True)
    
    class Meta:
        db_table = 'short_url'