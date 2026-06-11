package com.example.travelnoise.ui.music;

import android.graphics.Color;
import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.media3.common.MediaItem;
import androidx.media3.exoplayer.ExoPlayer;
import androidx.media3.ui.PlayerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.bumptech.glide.Glide;
import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.Model.MusicExerciseModel;
import com.example.travelnoise.Model.MusicExerciseOptionsModel;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentExerciseBinding;
import com.example.travelnoise.databinding.FragmentTheoryBinding;
import com.example.travelnoise.services.ApiClient;
import com.example.travelnoise.services.BundleKeys;
import com.example.travelnoise.ui.City.CityDescriptionFragment;
import com.google.android.material.card.MaterialCardView;
import com.pierfrancescosoffritti.androidyoutubeplayer.core.player.YouTubePlayer;
import com.pierfrancescosoffritti.androidyoutubeplayer.core.player.listeners.AbstractYouTubePlayerListener;
import com.pierfrancescosoffritti.androidyoutubeplayer.core.player.views.YouTubePlayerView;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link ExerciseFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class ExerciseFragment extends Fragment {

    private MaterialCardView previousChoise;
    private boolean currentAnswer;
    private ExoPlayer player;

    // TODO: Rename and change types of parameters
    private int mGenreId;
    private String mCategory;
    private FragmentExerciseBinding binding;
    private MaterialCardView selectedCard;

    public ExerciseFragment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mGenreId = getArguments().getInt(BundleKeys.ARG_GENREID);
            mCategory = getArguments().getString(BundleKeys.ARG_CATEGORY);
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentExerciseBinding.inflate(inflater, container, false);

        showExercise(mCategory);


        // Inflate the layout for this fragment
        return binding.getRoot();
    }

    private void showExercise(String type) {

        // first hide everything
        binding.HarmonyExercise.setVisibility(View.GONE);
        binding.ChordExercise.setVisibility(View.GONE);
        binding.RythmExercise.setVisibility(View.GONE);
        binding.InstrumentsExercise.setVisibility(View.GONE);

        switch (type) {

            case "Harmony":
                binding.HarmonyExercise.setVisibility(View.VISIBLE);
                submitButton(binding.harmonySubmitBtn);
                fillExerciseData("Harmony", mGenreId, binding.harmonyAnswerContainer, binding.harmonyPlayerView, binding.harmonyQuestion);

                break;

            case "Chords":
                binding.ChordExercise.setVisibility(View.VISIBLE);
                submitButton(binding.chordsSubmitBtn);
                fillExerciseData("Chords", mGenreId, binding.chordsAnswerContainer, binding.chordPlayerView, binding.chordQuestion);
                break;

            case "Rhythm":
                binding.RythmExercise.setVisibility(View.VISIBLE);
                submitButton(binding.rhythmSubmitBtn);
                fillExerciseData("Rhythm", mGenreId, binding.rhythmAnswerContainer, binding.rhythmPlayerView, binding.rhythmQuestion);
                break;

            case "Instruments":
                binding.InstrumentsExercise.setVisibility(View.VISIBLE);
                submitButton(binding.instrumentsSubmitBtn);
                fillExerciseData("Instruments", mGenreId, binding.instrumentsAnswerContainer, binding.instrumentPlayerView, binding.instrumentQuestion);
                break;

            default:
                // fallback (optional)
                binding.HarmonyExercise.setVisibility(View.GONE);
                binding.ChordExercise.setVisibility(View.GONE);
                binding.RythmExercise.setVisibility(View.GONE);
                binding.InstrumentsExercise.setVisibility(View.GONE);
                break;
        }
    }

    private void fillExerciseData(String category, int id, LinearLayout layout, PlayerView mp3player, TextView question) {
        ApiService apiService = ApiClient.getClient().create(ApiService.class);

        apiService.getMusicExercise(id, category).enqueue(new Callback<MusicExerciseModel>() {
            @Override
            public void onResponse(Call<MusicExerciseModel> call, Response<MusicExerciseModel> response) {
                Log.d("TEST", "onResponse: " + response);
                MusicExerciseModel exercise = response.body();
                question.setText(exercise.question);
                playAudio(exercise.videoUrl, mp3player);
                for (MusicExerciseOptionsModel exerciseOption : exercise.options) {
                    MaterialCardView answerCard = new MaterialCardView(requireContext());

                    LinearLayout.LayoutParams params =
                            new LinearLayout.LayoutParams(
                                    dpToPx(180),
                                    dpToPx(180));

                    params.setMarginEnd(dpToPx(12));

                    answerCard.setLayoutParams(params);
                    answerCard.setRadius(dpToPx(18));
                    answerCard.setStrokeWidth(5);
                    answerCard.setStrokeColor(Color.BLACK);

                    answerCard.setOnClickListener(v -> {
                        if (previousChoise != null) {
                            previousChoise.setStrokeColor(Color.BLACK);
                        }

                        answerCard.setStrokeColor(Color.RED);
                        previousChoise = answerCard;

                        currentAnswer = exerciseOption.isCorrect;
                        Log.d("TEST", "onResponse: " + currentAnswer);
                    });
                    ImageView image = new ImageView(requireContext());
                    image.setLayoutParams(new ViewGroup.LayoutParams(
                            ViewGroup.LayoutParams.MATCH_PARENT,
                            ViewGroup.LayoutParams.MATCH_PARENT));

                    image.setScaleType(ImageView.ScaleType.CENTER_INSIDE);
                    Glide.with(ExerciseFragment.this)
                            .load(exerciseOption.images.get(0).imageURL)
                            .into(image);
                    answerCard.addView(image);
                    layout.addView(answerCard);
                }
            }

            @Override
            public void onFailure(Call<MusicExerciseModel> call, Throwable throwable) {
                Log.d("TEST", "onFailure: " + call + throwable);
            }
        });

    }
    private void playAudio(String url, PlayerView mp3Player) {

        if (player != null) {
            player.release();
        }

        player = new ExoPlayer.Builder(requireContext()).build();
        mp3Player.setPlayer(player);

        player.setMediaItem(MediaItem.fromUri(url));
        player.prepare();
        player.play();
    }
    private void submitButton(Button button) {
        button.setOnClickListener(v -> {
            Log.d("TEST", "submitButton: you got here");
            if (currentAnswer)
                Toast.makeText(requireContext(), "Correct!", Toast.LENGTH_SHORT).show();
            else
                Toast.makeText(requireContext(), "WRONG GID GUD SCRUB!", Toast.LENGTH_SHORT).show();

        });
    }



    private int dpToPx(int dp) {
        return (int) (dp * getResources().getDisplayMetrics().density);
    }

    private int parseDp(String value) {
        if (value == null) return 0;
        return Integer.parseInt(value.replace("dp", "").replace("px", ""));
    }
}