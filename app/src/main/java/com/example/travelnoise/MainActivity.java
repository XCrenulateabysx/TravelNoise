package com.example.travelnoise;

import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;
import androidx.navigation.NavController;
import androidx.navigation.Navigation;

import com.example.travelnoise.databinding.ActivityMainBinding;

public class MainActivity extends AppCompatActivity {

    private ActivityMainBinding binding;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());

        NavController navController =
                Navigation.findNavController(this, R.id.nav_host_fragment_activity_main);

        binding.navView.setOnItemSelectedListener(item -> {

            int id = item.getItemId();

            // HOME Navigation
            if (id == R.id.navigation_home) {

                navController.popBackStack(R.id.navigation_home, false);

                return true;
            }

            // vote
            if (id == R.id.navigation_dashboard) {

                if (navController.getCurrentDestination() != null &&
                        navController.getCurrentDestination().getId() != R.id.navigation_dashboard) {

                    navController.navigate(R.id.navigation_dashboard);
                }

                return true;
            }

            return false;
        });
    }
}