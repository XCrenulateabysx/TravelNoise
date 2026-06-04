package com.example.travelnoise.Model;

public class LocationModel {
    public int id;
    public String buttonX;
    public String buttonY;
    public String regionName;
    public String regionDescription;
    public int pageid;
    public int genreid;
    public PageModel Page;
    public GenreModel Genre;
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
