package com.example.travelnoise.ui.home;

import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageButton;
import android.widget.ImageView;

import androidx.annotation.NonNull;
import androidx.constraintlayout.widget.ConstraintLayout;
import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import com.example.travelnoise.IServices.ApiService;
import com.example.travelnoise.Model.LocationModel;
import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentHomeBinding;
import com.example.travelnoise.services.ApiClient;

import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class HomeFragment extends Fragment {

    private FragmentHomeBinding binding;

    private static final String ARG_TITLE = "title";
    private static final String ARG_DESCRIPTION = "description";
    private static final String ARG_IMGURL = "imageURL";


    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container,
                             Bundle savedInstanceState) {
        Log.d("NAV", "HomeFragment loaded");

        ApiService apiService = ApiClient.getClient().create(ApiService.class);
        Log.d("TEST", "onResponse: no response" );
        binding = FragmentHomeBinding.inflate(inflater, container, false);
        ConstraintLayout layout = binding.HomeConstraint;
        apiService.getRegions().enqueue(new Callback<List<LocationModel>>()
        {
            @Override
            public void onResponse(Call<List<LocationModel>> call, Response<List<LocationModel>> response)
            {
                Log.d("TEST", "onResponse: no response2" + response.body());

                if(response.isSuccessful() && response.body() != null)
                {
                    List<LocationModel> locations = response.body();
                    for ( LocationModel location: locations )
                    {
                        int size = dpToPx(28);
                        ImageButton imageButton = new ImageButton(requireContext());
                        imageButton.setImageResource(R.drawable.star);
                        imageButton.setBackgroundColor(Color.TRANSPARENT);
                        imageButton.setScaleType(ImageView.ScaleType.FIT_CENTER);
                        imageButton.setPadding(0, 0, 0, 0);

                        ConstraintLayout.LayoutParams params =
                                new ConstraintLayout.LayoutParams(size, size);

                        params.leftToLeft = ConstraintLayout.LayoutParams.PARENT_ID;
                        params.topToTop = ConstraintLayout.LayoutParams.PARENT_ID;

                        int x = parseDp(location.buttonX);
                        int y = parseDp(location.buttonY);

                        params.setMargins(dpToPx(x), dpToPx(y), 0, 0);




                        if(location.page != null)
                            Log.d("TEST", "onResponse: " + location.page.pageDescription + location.page.pageTitle);

                        imageButton.setLayoutParams(params);

                        imageButton.setOnClickListener(v ->{


                            Bundle bundle = new Bundle();
                            if(location.page != null)
                            {
                                Log.d("TEST", "onResponse: " + location.page.pageDescription + location.page.pageTitle);
                                bundle.putString(ARG_TITLE, location.page.pageTitle);

                                bundle.putString(
                                        ARG_DESCRIPTION,
                                        location.page.pageDescription
                                );
                            }
                            bundle.putString(ARG_IMGURL, "http://10.0.2.2:5035/images/WTTTTTTTTTF.png");
                            Navigation.findNavController(v)
                                    .navigate(R.id.action_navigation_home_to_CityDescriptionFragment, bundle);
                        });

                        layout.addView(imageButton);
                    }
                }
            }

            @Override
            public void onFailure(Call<List<LocationModel>> call, Throwable throwable) {

            }
        });



        return binding.getRoot();
    }

    @Override
    public void onDestroyView() {
        super.onDestroyView();
        binding = null;
    }

    private int dpToPx(int dp) {
        return (int) (dp * getResources().getDisplayMetrics().density);
    }

    private int parseDp(String value) {
        if (value == null) return 0;
        return Integer.parseInt(value.replace("dp", "").replace("px", ""));
    }
}