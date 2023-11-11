
from rest_framework.response import Response
from rest_framework.decorators import api_view
from rest_framework import status
from django.utils import timezone
from datetime import timedelta
from .utils import generateUniqueShortText
from django.shortcuts import redirect, get_object_or_404
from django.http import  JsonResponse

from .models import ShortUrl
from .serializers import ShortUrlSerializer

@api_view(['GET'])
def getShortUrlList(request):
    urls = ShortUrl.objects.all()
    serializer = ShortUrlSerializer(urls, many = True)
    return Response(serializer.data)

@api_view(['GET'])
def findOriginalUrl(request, pk):
    domain = "http://127.0.0.1:8000/" + pk
    try:
        find_url = get_object_or_404(
            ShortUrl,
            shortAlias=domain,
            expirationDateTime__gte=timezone.now()
        )
        return redirect(find_url.originalUrl)
    except ShortUrl.DoesNotExist:
        return JsonResponse({"error": "Short URL not found"}, status=404)

@api_view(['POST'])
def createShortUrl(request):
    if request.method == 'POST':
        data = request.data
        print(request)
        originalUrl = data.get('originalUrl')
        idExpiration = data.get('idExpiration')

        dateTimeExpiration = timezone.now()

        if idExpiration == "1":
            dateTimeExpiration += timezone.timedelta(minutes=1)
        elif idExpiration == "2":
            dateTimeExpiration += timezone.timedelta(minutes=5)
        elif idExpiration == "3":
            dateTimeExpiration += timezone.timedelta(minutes=30)
        elif idExpiration == "4":
            dateTimeExpiration += timezone.timedelta(hours=1)
        elif idExpiration == "5":
            dateTimeExpiration += timezone.timedelta(hours=5)

        check_if_existed = ShortUrl.objects.filter(originalUrl=originalUrl, expirationDateTime__gte=timezone.now())

        if check_if_existed:
            return Response({"message": f"This URL '{originalUrl}' already exists"}, status=status.HTTP_409_CONFLICT)

        domainUrl = "http://127.0.0.1:8000/"
        short_alias = domainUrl + generateUniqueShortText()

        url = ShortUrl.objects.create(
            shortAlias=short_alias,
            originalUrl=originalUrl,
            expirationDateTime=dateTimeExpiration
        )

        return Response({"message": "Short URL created successfully"}, status=status.HTTP_201_CREATED)
    else:
        return Response({"message": "Invalid request method"}, status=status.HTTP_405_METHOD_NOT_ALLOWED)

@api_view(['DELETE'])
def deleteUrlRow(request, pk):
    try:
        url =ShortUrl.objects.get(id = pk)
    except ShortUrl.DoesNotExist:
        return Response(status= status.HTTP_404_NOT_FOUND)
    url.delete()
    return Response(status= status.HTTP_200_OK)