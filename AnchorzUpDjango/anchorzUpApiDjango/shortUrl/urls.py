from django.urls import path
from . import views

urlpatterns = [
        path('list/', views.getShortUrlList, name='list'),
        path('delete/<str:pk>/', views.deleteUrlRow, name="delete"),
        path('add/', views.createShortUrl, name='create'),
        # path('a/<str:pk>', views.findOriginalUrl, name="find-url")
]