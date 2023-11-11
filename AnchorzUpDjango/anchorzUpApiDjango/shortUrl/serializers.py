from rest_framework.serializers import ModelSerializer
from .models import ShortUrl

class ShortUrlSerializer(ModelSerializer):
    class Meta:
        model = ShortUrl
        fields= '__all__'
        # exclude = ('id',)