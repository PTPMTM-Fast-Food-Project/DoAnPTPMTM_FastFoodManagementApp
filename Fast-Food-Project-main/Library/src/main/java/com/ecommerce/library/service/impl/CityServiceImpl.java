package com.ecommerce.library.service.impl;

import com.ecommerce.library.model.City;
import com.ecommerce.library.repository.CityRepository;
import com.ecommerce.library.service.CityService;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CityServiceImpl implements CityService {
    private final CityRepository cityRepository;

    public CityServiceImpl(CityRepository cityRepository) {
        this.cityRepository = cityRepository;
    }

    @Override
    public List<City> findAll() {
        return cityRepository.findAll();
    }
}
