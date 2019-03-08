﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json.Linq;

namespace CienciaArgentina.Microservices.Commons.Helpers.OAuth2
{
    public class OAuth2Helper
    {
        public static void GoogleOAuth2Options(OAuthOptions options)
        {
            // TODO: move this into a config file
            options.ClientId = "1061335654991-o23odngegp0k14th335s3cf39m8kuhrs.apps.googleusercontent.com";
            options.ClientSecret = "_MaGsHaes057tndh0KoR1LWO";
            options.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/auth";
            options.TokenEndpoint = "https://oauth2.googleapis.com/token";
            options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v2/userinfo";

            options.Scope.Add("profile");

            options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "UserId");
            options.ClaimActions.MapJsonKey(ClaimTypes.Email, "Email", ClaimValueTypes.Email);
            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "Name");

            // After OAuth2 has authenticated the user
            options.Events = new OAuthEvents
            {
                // After OAuth2 has authenticated the user
                OnCreatingTicket = async context =>
                {
                        // Create the request message to get user data via the backchannel
                        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                        // Additional header if needed. Here's an example to go through Azure API Management 
                        request.Headers.Add("Ocp-Apim-Subscription-Key", "<given key>");

                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Query for user data via backchannel
                        var response = await context.Backchannel.SendAsync(request, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();

                        // Parse user data into an object
                        var user = JObject.Parse(await response.Content.ReadAsStringAsync());

                        // Store the received authentication token somewhere. In a cookie for example
                        context.HttpContext.Response.Cookies.Append("token", context.AccessToken);

                        // Execute defined mapping action to create the claims from the received user object
                        context.RunClaimActions(JObject.FromObject(user));
                },
                OnRemoteFailure = context =>
                {
                    context.HandleResponse();
                    context.Response.Redirect("/Home/Error?message=" + context.Failure.Message);
                    return Task.FromResult(0);
                }
            };
        }
    }
}
