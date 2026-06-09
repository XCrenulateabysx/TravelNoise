package com.example.travelnoise.Model;

import java.util.List;
import java.util.UUID;

public class PageModel
{
    public int id;

    public String pageDescription;

    public String pageTitle;

    public UUID userid;
    public List<ImageModel> images;
    public int genreid;
    public LocationModel location;
    public UserModel user;

    public List<PageGenreModel> PageGenre;
}
