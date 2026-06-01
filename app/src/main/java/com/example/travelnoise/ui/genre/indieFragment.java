package com.example.travelnoise.ui.genre;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.navigation.Navigation;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.travelnoise.R;
import com.example.travelnoise.databinding.FragmentHomeBinding;
import com.example.travelnoise.databinding.FragmentIndieBinding;

/**
 * A simple {@link Fragment} subclass.
 * Use the {@link indieFragment#newInstance} factory method to
 * create an instance of this fragment.
 */
public class indieFragment extends Fragment {

    // TODO: Rename parameter arguments, choose names that match
    // the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
    private static final String ARG_PARAM1 = "param1";
    private static final String ARG_PARAM2 = "param2";

    // TODO: Rename and change types of parameters
    private String mParam1;
    private String mParam2;

    private FragmentIndieBinding binding;
    public indieFragment() {
        // Required empty public constructor
    }

    /**
     * Use this factory method to create a new instance of
     * this fragment using the provided parameters.
     *
     * @param param1 Parameter 1.
     * @param param2 Parameter 2.
     * @return A new instance of fragment indieFragment.
     */
    // TODO: Rename and change types and number of parameters
    public static indieFragment newInstance(String param1, String param2) {
        indieFragment fragment = new indieFragment();
        Bundle args = new Bundle();
        args.putString(ARG_PARAM1, param1);
        args.putString(ARG_PARAM2, param2);
        fragment.setArguments(args);


        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getString(ARG_PARAM1);
            mParam2 = getArguments().getString(ARG_PARAM2);
        }



    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding = FragmentIndieBinding.inflate(inflater, container, false);

        binding.button6.setOnClickListener(v -> {
            Bundle bundle = new Bundle();

            bundle.putString("title", "Indie Music");

            bundle.putString(
                    "description",
                    "Indie music focuses on independent artists."
            );

            bundle.putString(
                    "imageURL",
                    "https://10.0.2.2:5035/images/test.png"
            );
            Navigation.findNavController(v)
                    .navigate(R.id.action_indieFragment_to_theoryFragment, bundle);
        });
        // Inflate the layout for this fragment
        return binding.getRoot();
    }
}