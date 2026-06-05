package com.example.travelnoise.Model;

import java.util.UUID;

public class PageModel
{
    public int id;

    public String pageDescription;

    public String pageTitle;

    public UUID userid;

    public int genreid;
    public LocationModel location;
    public UserModel user;

    public GenreModel genre;
}
