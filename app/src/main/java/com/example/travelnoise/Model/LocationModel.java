package com.example.travelnoise.Model;

import java.util.List;

public class LocationModel {
    public int id ;
    public String regionName ;
    public String regionDescription ;
    public float buttonX ;
    public float buttonY ;
    public int pageid ;
    public int genreid ;
    public ImageModel image ;
    public PageModel page ;
    public GenreModel genre ;
    @Override
    public String toString() {
        return "LocationModel{" +
                "id=" + id +
                ", regionName='" + regionName + '\'' +
                ", regionDescription='" + regionDescription + '\'' +
                ", buttonX='" + buttonX + '\'' +
                ", buttonY='" + buttonY + '\'' +
                '}';
    }
}
