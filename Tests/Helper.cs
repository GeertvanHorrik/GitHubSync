﻿using System;
using Octokit;

public static class Helper
{
    static readonly Lazy<Credentials> credentialsThunk = new Lazy<Credentials>(() =>
    {
        var githubToken = Environment.GetEnvironmentVariable("Octokit_OAuthToken");

        if (githubToken != null)
        {
            return new Credentials(githubToken);
        }

        return Credentials.Anonymous;
    });

    public static Credentials Credentials => credentialsThunk.Value;
}