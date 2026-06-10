package com.example.travelnoise.Model;

import java.util.List;

public class MusicExerciseModel {
    public int id;
    public String type;
    public String question;
    public String videoUrl;
    public int set;
    public int genreId;
    public GenreModel genre;
    public List<MusicExerciseOptionsModel> options;
}
