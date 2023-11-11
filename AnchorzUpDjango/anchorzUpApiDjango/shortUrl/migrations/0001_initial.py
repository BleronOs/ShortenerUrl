# Generated by Django 4.2.7 on 2023-11-11 17:50

import anchorzUpApiDjango.token
from django.db import migrations, models
import uuid


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='ShortUrl',
            fields=[
                ('id', anchorzUpApiDjango.token.TokenIDField(default=uuid.uuid4, max_length=255, primary_key=True, serialize=False, unique=True)),
                ('originalUrl', models.TextField()),
                ('shortAlias', models.CharField(max_length=60)),
                ('created', models.DateTimeField(auto_now=True)),
                ('expirationDateTime', models.DateTimeField(blank=True, null=True)),
            ],
            options={
                'db_table': 'short_url',
            },
        ),
    ]
